using System.ComponentModel.DataAnnotations;

namespace Events.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Empty Field ! ")]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
