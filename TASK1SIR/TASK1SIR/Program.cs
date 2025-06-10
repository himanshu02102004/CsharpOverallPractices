using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContinuousAccessDbSync
{
    class Program
    {
        private static bool _syncRunning = true;
        private static DateTime _lastClientSyncTime;
        private static DateTime _lastServerSyncTime;

        static async Task Main()
        {
            string clientDbPath = @"C:\Users\Nimap\Documents\Himanshu\himanshu.mdb";
            string serverDbPath = @"\\192.168.1.93\mdbfile\rajat.mdb";
            const string tableName = "People";
            const string pkColumn = "ID"; // Primary key column
            const string valueColumn = "Name"; // The column where value conflicts lead to new records

            if (!VerifyDatabaseFiles(clientDbPath, serverDbPath))
            {
                Console.ReadKey();
                return;
            }

            // Using Microsoft.ACE.OLEDB.12.0 for .accdb and newer .mdb, for older .mdb use 4.0
            string clientConnStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={clientDbPath};";
            string serverConnStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={serverDbPath};";

            if (!TestConnection("Client DB", clientConnStr) || !TestConnection("Server DB", serverConnStr))
            {
                Console.ReadKey();
                return;
            }

            // Initialize last sync times from DB or fallback to MinValue
            // We get the max LastModified from the *other* database to know what we last pulled
            _lastClientSyncTime = GetMaxLastModified(serverConnStr, tableName);
            _lastServerSyncTime = GetMaxLastModified(clientConnStr, tableName);

            Console.WriteLine("\nStarting continuous synchronization...");
            Console.WriteLine("Press 'Q' then Enter to stop synchronization.\n");

            var syncTask = Task.Run(() => ContinuousSync(serverConnStr, clientConnStr, tableName, pkColumn, valueColumn));

            while (true)
            {
                var input = Console.ReadLine();
                if (string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    _syncRunning = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Press 'Q' then Enter to stop synchronization.");
                }
            }

            await syncTask;

            Console.WriteLine("Synchronization stopped. Press any key to exit.");
            Console.ReadKey();
        }

        static bool VerifyDatabaseFiles(string clientPath, string serverPath)
        {
            if (!File.Exists(clientPath))
            {
                Console.WriteLine($"Client database not found at: {clientPath}");
                return false;
            }

            // Check if server path is a network path and if it's accessible
            if (serverPath.StartsWith(@"\\"))
            {
                try
                {
                    string directory = Path.GetDirectoryName(serverPath);
                    if (!Directory.Exists(directory))
                    {
                        Console.WriteLine($"Server directory not found or not accessible: {directory}");
                        return false;
                    }
                    if (!File.Exists(serverPath))
                    {
                        Console.WriteLine($"Server database not found at: {serverPath}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing server path: {ex.Message}");
                    return false;
                }
            }
            else // Local server path
            {
                if (!File.Exists(serverPath))
                {
                    Console.WriteLine($"Server database not found at: {serverPath}");
                    return false;
                }
            }

            return true;
        }

        static bool TestConnection(string name, string connectionString)
        {
            Console.WriteLine($"Testing {name} connection...");
            try
            {
                using var connection = new OleDbConnection(connectionString);
                connection.Open();
                Console.WriteLine($"{name} connection successful.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{name} connection failed: {ex.Message}");
                return false;
            }
        }

        static DateTime GetMaxLastModified(string connectionString, string tableName)
        {
            try
            {
                using var conn = new OleDbConnection(connectionString);
                conn.Open();
                // Ensure tableName is correctly quoted
                using var cmd = new OleDbCommand($"SELECT MAX(LastModified) FROM [{tableName}]", conn);
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                    return Convert.ToDateTime(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching max LastModified from {connectionString}: {ex.Message}");
            }
            return DateTime.MinValue;
        }

        static async Task ContinuousSync(string serverConnStr, string clientConnStr, string tableName, string pkColumn, string valueColumn)
        {
            while (_syncRunning)
            {
                try
                {
                    Console.WriteLine($"[{DateTime.Now:T}] Syncing Server -> Client...");
                    // Using ref for lastSyncTime to update it in the calling scope
                    int serverToClientChanges = SyncDirection(serverConnStr, clientConnStr, tableName, pkColumn, valueColumn, ref _lastClientSyncTime);
                    Console.WriteLine($"[{DateTime.Now:T}] Server -> Client: {serverToClientChanges} changes applied.");

                    Console.WriteLine($"[{DateTime.Now:T}] Syncing Client -> Server...");
                    // Note: Here _lastServerSyncTime represents the last time we pulled from the client to push to server
                    int clientToServerChanges = SyncDirection(clientConnStr, serverConnStr, tableName, pkColumn, valueColumn, ref _lastServerSyncTime);
                    Console.WriteLine($"[{DateTime.Now:T}] Client -> Server: {clientToServerChanges} changes applied.");

                    // Handle deletions after insert/update
                    // Ensure connections are opened and closed within the SyncDeletions or passed correctly
                    using (var serverConn = new OleDbConnection(serverConnStr))
                    using (var clientConn = new OleDbConnection(clientConnStr))
                    {
                        serverConn.Open();
                        clientConn.Open();
                        Console.WriteLine($"[{DateTime.Now:T}] Syncing Server -> Client Deletions...");
                        SyncDeletions(serverConn, clientConn, tableName, pkColumn); // Server -> Client deletions
                        Console.WriteLine($"[{DateTime.Now:T}] Syncing Client -> Server Deletions...");
                        SyncDeletions(clientConn, serverConn, tableName, pkColumn); // Client -> Server deletions
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{DateTime.Now:T}] Sync error: {ex.Message}");
                }

                await Task.Delay(5000); // Sync every 5 seconds
            }
        }

        static int SyncDirection(string sourceConnStr, string targetConnStr, string tableName, string pkColumn, string valueColumn, ref DateTime lastSyncTime)
        {
            int changesApplied = 0;
            DateTime maxTimestampInThisSync = lastSyncTime; // Track the latest timestamp seen in this batch

            using var sourceConn = new OleDbConnection(sourceConnStr);
            using var targetConn = new OleDbConnection(targetConnStr);

            sourceConn.Open();
            targetConn.Open();

            // Get the next available ID in target DB for new inserts due to conflicts
            int nextId = GetNextAvailableId(targetConn, tableName, pkColumn);

            // Get all changed records from source since last sync time
            // Use 'CDate' to ensure proper date comparison in Access SQL
            string getChangesQuery = $@"
                SELECT * FROM [{tableName}]
                WHERE LastModified > CDate('{lastSyncTime:MM/dd/yyyy hh:mm:ss tt}')
                ORDER BY LastModified";

            using (var cmd = new OleDbCommand(getChangesQuery, sourceConn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sourceRow = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sourceRow[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                        }

                        object currentPKValue = sourceRow[pkColumn];
                        var incomingLastModified = Convert.ToDateTime(sourceRow["LastModified"]);

                        // Check if record exists in target
                        bool recordExistsInTarget = RecordExists(targetConn, tableName, pkColumn, currentPKValue);

                        if (recordExistsInTarget)
                        {
                            // Get target's LastModified for comparison
                            var targetLastModified = GetLastModified(targetConn, tableName, pkColumn, currentPKValue);

                            // If source is older or same, no need to update or resolve conflict
                            if (incomingLastModified <= targetLastModified)
                            {
                                // Even if not applied, update maxTimestampInThisSync if this row is newer
                                if (incomingLastModified > maxTimestampInThisSync)
                                {
                                    maxTimestampInThisSync = incomingLastModified;
                                }
                                continue;
                            }

                            // Conflict resolution: Check if valueColumn has changed in target compared to source
                            string targetOldValue = GetColumnValue(targetConn, tableName, pkColumn, currentPKValue, valueColumn)?.ToString();
                            string sourceNewValue = sourceRow[valueColumn]?.ToString();

                            if (targetOldValue != null && !targetOldValue.Equals(sourceNewValue, StringComparison.OrdinalIgnoreCase))
                            {
                                // Value conflict: Target has a different value for the same ID
                                // 1. Update the existing record in target with source's new value
                                UpdateRecord(targetConn, tableName, pkColumn, currentPKValue, sourceRow);
                                changesApplied++;
                                Console.WriteLine($"Updated record with ID {currentPKValue} in target. Old value: '{targetOldValue}' replaced with '{sourceNewValue}'.");

                                // 2. Insert the old target value as a new record with a new ID
                                var oldTargetRowAsNew = new Dictionary<string, object>();
                                // Copy all fields from the source row except the primary key
                                foreach (var key in sourceRow.Keys.Where(k => k != pkColumn))
                                {
                                    oldTargetRowAsNew[key] = sourceRow[key];
                                }
                                oldTargetRowAsNew[pkColumn] = nextId; // Assign new ID
                                oldTargetRowAsNew[valueColumn] = targetOldValue; // Assign the old conflicting value
                                oldTargetRowAsNew["LastModified"] = DateTime.Now; // Set new LastModified for the new record

                                InsertRecord(targetConn, tableName, oldTargetRowAsNew);
                                Console.WriteLine($"Inserted old value '{targetOldValue}' (originally from ID {currentPKValue}) as new record with ID {nextId} in target.");
                                nextId++; // Increment for the next new ID
                                changesApplied++;
                            }
                            else
                            {
                                // No value conflict for the 'Name' column, just a normal update
                                UpdateRecord(targetConn, tableName, pkColumn, currentPKValue, sourceRow);
                                changesApplied++;
                            }
                        }
                        else
                        {
                            // Record does not exist in target, simply insert it
                            InsertRecord(targetConn, tableName, sourceRow);
                            changesApplied++;
                        }

                        // Update max timestamp for this sync batch
                        if (incomingLastModified > maxTimestampInThisSync)
                        {
                            maxTimestampInThisSync = incomingLastModified;
                        }
                    }
                }
            }

            lastSyncTime = maxTimestampInThisSync; // Update the reference for the next sync cycle
            return changesApplied;
        }


        // Gets the next available ID in a table
        static int GetNextAvailableId(OleDbConnection conn, string tableName, string pkColumn)
        {
            string query = $"SELECT MAX([{pkColumn}]) FROM [{tableName}]";
            using (var cmd = new OleDbCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
            }
        }

        // Retrieves a specific column value for a given primary key
        static object GetColumnValue(OleDbConnection conn, string tableName, string pkColumn, object pkValue, string columnName)
        {
            string query = $"SELECT [{columnName}] FROM [{tableName}] WHERE [{pkColumn}] = ?";
            using (var cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue($"@{pkColumn}", pkValue);
                return cmd.ExecuteScalar();
            }
        }

        static void InsertRecord(OleDbConnection conn, string tableName, Dictionary<string, object> row)
        {
            var columns = row.Keys.ToList();
            var columnList = string.Join(", ", columns.Select(c => $"[{c}]"));
            var valuePlaceholders = string.Join(", ", columns.Select(_ => "?"));

            string insertQuery = $@"
                INSERT INTO [{tableName}] ({columnList})
                VALUES ({valuePlaceholders})";

            using (var cmd = new OleDbCommand(insertQuery, conn))
            {
                foreach (var col in columns)
                {
                    // Ensure that DateTime values are handled correctly for Access
                    if (row[col] is DateTime dateTimeValue)
                    {
                        cmd.Parameters.AddWithValue($"@{col}", dateTimeValue.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue($"@{col}", row[col] ?? DBNull.Value);
                    }
                }
                cmd.ExecuteNonQuery();
            }
        }

        static void UpdateRecord(OleDbConnection conn, string tableName, string pkColumn, object pkValue, Dictionary<string, object> row)
        {
            var columns = row.Keys.Where(k => k != pkColumn).ToList(); // Don't update PK
            var updateSet = string.Join(", ", columns.Select(c => $"[{c}] = ?"));

            string updateQuery = $@"
                UPDATE [{tableName}]
                SET {updateSet}
                WHERE [{pkColumn}] = ?";

            using (var cmd = new OleDbCommand(updateQuery, conn))
            {
                foreach (var col in columns)
                {
                    // Ensure that DateTime values are handled correctly for Access
                    if (row[col] is DateTime dateTimeValue)
                    {
                        cmd.Parameters.AddWithValue($"@{col}", dateTimeValue.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue($"@{col}", row[col] ?? DBNull.Value);
                    }
                }
                cmd.Parameters.AddWithValue($"@{pkColumn}", pkValue);
                cmd.ExecuteNonQuery();
            }
        }

        static DateTime GetLastModified(OleDbConnection conn, string tableName, string pkColumn, object pkValue)
        {
            string query = $"SELECT LastModified FROM [{tableName}] WHERE [{pkColumn}] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue($"@{pkColumn}", pkValue);
            var result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToDateTime(result) : DateTime.MinValue;
        }

        static bool RecordExists(OleDbConnection conn, string tableName, string pkColumn, object pkValue)
        {
            string query = $"SELECT COUNT(*) FROM [{tableName}] WHERE [{pkColumn}] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue($"@{pkColumn}", pkValue);
            return (int)cmd.ExecuteScalar() > 0;
        }

        static void SyncDeletions(OleDbConnection sourceConn, OleDbConnection targetConn, string tableName, string pkColumn)
        {
            var sourceIds = GetAllIds(sourceConn, tableName, pkColumn);
            var targetIds = GetAllIds(targetConn, tableName, pkColumn);

            var toDeleteInTarget = targetIds.Except(sourceIds).ToList();

            foreach (var id in toDeleteInTarget)
            {
                ring deleteQuery = $"DELETE FROM [{tableName}] WHERE [{pkColumn}] = ?";
                using var cmd = new OleDbCommand(deleteQuery, targetConn);
                cmd.Parameters.AddWithValue($"@{pkColumn}", id);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Deleted ID {id} from target database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting ID {id} from target: {ex.Message}");
                }
            }
        }

        static List<int> GetAllIds(OleDbConnection conn, string tableName, string pkColumn)
        {
            var ids = new List<int>();
            string query = $"SELECT [{pkColumn}] FROM [{tableName}]";

            try
            {
                using var cmd = new OleDbCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all IDs from {conn.DataSource}: {ex.Message}");
            }
            return ids;
        }
    }
}