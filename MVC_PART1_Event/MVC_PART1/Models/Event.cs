using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC_PART1.Models
{ 

public class Event
{
    public int ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EventDate { get; set; }

    public string Location { get; set; }

    public int capacity { get; set; }




        [ValidateNever] // Skip validation
        public ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();  

    }

    }



