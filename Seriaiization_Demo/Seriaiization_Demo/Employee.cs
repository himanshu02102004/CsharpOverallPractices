using System;
using System.Text.Json.Serialization;

namespace Seriaiization_Demo
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

     //   public Employee() { }

        [JsonConstructor]
        public Employee(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
