using System.ComponentModel.DataAnnotations;

namespace UsersMicroserviceAPI.Models;

public class UserProfile
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Location { get; set; }
    public string Bio { get; set; }
    public List<string> Interests { get; set; }
    [Required]
    public List<string> Photos { get; set; } // URLs of user photos
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}