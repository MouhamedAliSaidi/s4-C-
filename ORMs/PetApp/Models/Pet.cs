using System.ComponentModel.DataAnnotations;

namespace PetApp.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Pet Type")]
        public string PetType { get; set; }

        public int Age { get; set; }

        [Display(Name = "Has Fur?")]
        public bool HasFur { get; set; }
    }
}
