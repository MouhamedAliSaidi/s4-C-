using System.ComponentModel.DataAnnotations;

namespace DojoSurvey3.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Favorite Language is required.")]
        public string Language { get; set; }

        [MinLength(21, ErrorMessage = "Comment must be longer than 20 characters.")]
        public string Comment { get; set; }
    }
}
