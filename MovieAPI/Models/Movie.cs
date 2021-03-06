using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The field Director is required")]
        public string Director { get; set; }
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "The field Duration should have the value between 1 and 600 is required")]
        public int Duration { get; set; }
    }
}
