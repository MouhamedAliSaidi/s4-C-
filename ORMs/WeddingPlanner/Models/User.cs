using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }

    [NotMapped, Compare("Password")]
    public string PasswordConfirm { get; set; }

    public List<Wedding> WeddingsPlanned { get; set; } = new();
    public List<RSVP> WeddingsAttending { get; set; } = new();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
