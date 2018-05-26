using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ECommerce.Features.Authentication
{
  public class RefreshTokenViewModel
  {
    [Required, JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
  }
}