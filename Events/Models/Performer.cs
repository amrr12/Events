using System.ComponentModel.DataAnnotations;

namespace Events.Models
{
    public class Performer : User
    {

        [Required(ErrorMessage = "Empty Field ! ")]
        public string Perform {  get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        [MinLength(255)]
        public string Description { get; set; }

      
        [Required(ErrorMessage = "Empty Field ! ")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]

        public string TelNmber {  get; set; }

        [Required]
        

        public virtual ICollection<Application>? Applications { get; set; } = new List<Application>();


    }
}
