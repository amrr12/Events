using System.ComponentModel.DataAnnotations;

namespace Events.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        [MaxLength(255)]
        public string Title { get; set;}

        [Required(ErrorMessage = "Empty Field ! ")]
        public string Description { get; set;}

        [Required(ErrorMessage = "Empty Field ! ")]
        [MaxLength(100)]
        public string Location { get; set;}

        [Required(ErrorMessage = "Empty Field ! ")]
        [FutureDate]
        public DateTime Date { get; set;}

        [Required(ErrorMessage = "Empty Field ! ")]
        public virtual Owner Owner { get; set; }

        public int OwnerId {  get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]

        public string Duration { get; set; }

        public virtual ICollection<Application>? Applications { get; set; } = new List<Application>();

    }

    internal class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            return date > DateTime.Now;
        }
    }
}
