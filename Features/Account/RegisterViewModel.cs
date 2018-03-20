using System.ComponentModel.DataAnnotations;

namespace ECommerce.Features.Account
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
  }
}