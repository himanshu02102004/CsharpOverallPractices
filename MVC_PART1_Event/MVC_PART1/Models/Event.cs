using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace MVC_PART1.Models
{
    public class Event
    {

        public int ID { get; set; }

        public string Name { get; set; }
        public required string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        public string  Location  { get; set; }


        public int capacity { get; set; }

        public ICollection<EventRegistration> Registrations { get; set; }




    }



}
