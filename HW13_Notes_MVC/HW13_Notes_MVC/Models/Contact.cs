using System.ComponentModel.DataAnnotations;

namespace HW13_Notes_MVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(13)]
        public string Phone { get; set; }

        [MaxLength(13)]
        public string AddPhone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
