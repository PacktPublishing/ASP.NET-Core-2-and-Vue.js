using System.ComponentModel.DataAnnotations;

namespace ECommerce.Features.Authentication
{
  public class LoginViewModel
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}