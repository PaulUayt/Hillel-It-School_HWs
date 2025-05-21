using System.ComponentModel.DataAnnotations;

namespace HW13_Notes_MVC.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Tag is required")]
        [MaxLength(50)]
        public string Tag { get; set; }

    }
}
