using System.ComponentModel.DataAnnotations;

namespace TreeTalk.Model.ViewModels;

public class RegisterViewModel
{
  [Required]
  public string? Username { get; set; }

  [Required]
  [EmailAddress]
  public string? Email { get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string? Password { get; set; }

  [Required]
  [DataType(DataType.Date)]
  public DateTime Birthday { get; set; }

  [Required]
  public string? Gender { get; set; } 
}
