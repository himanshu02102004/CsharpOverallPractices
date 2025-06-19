namespace MVC_PART1.Models
{
    public class EventRegistration
    {


        public int Id { get; set; }

        public int EventId{ get; set; }
        public Event Events { get; set; }

        public int UserId { get; set; }
        public User  Users { get ; set; }




    }
}
