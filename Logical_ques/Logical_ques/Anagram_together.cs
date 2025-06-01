//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{
//    class Anagram_together
//    {
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class Solution
//{
//    public IList<IList<string>> GroupAnagrams(string[] strs)
//    {
//        Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();

//        foreach (string s in strs)
//        {
//            char[] chars = s.ToCharArray();
//            Array.Sort(chars);
//            string key = new string(chars);

//            if (!ans.ContainsKey(key))
//            {
//                ans[key] = new List<string>();
//            }
//            ans[key].Add(s);
//        }

//        return ans.Values.ToList<IList<string>>();
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // ✅ Direct input, as you wrote:
//        string[] str = { "eat", "tea", "tan", "ate", "nat", "bat" };

//        Solution sol = new Solution();
//        var groupedAnagrams = sol.GroupAnagrams(str);

//        Console.WriteLine("Output:");
//        foreach (var group in groupedAnagrams)
//        {
//            Console.Write("[");
//            Console.Write(string.Join(", ", group.Select(s => $"\"{s}\"")));
//            Console.WriteLine("]");
//        }
//    }
//}
