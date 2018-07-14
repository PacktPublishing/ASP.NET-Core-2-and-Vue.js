using System;
using Newtonsoft.Json;

namespace ECommerce.Features.Authentication
{
  public class TokenViewModel
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("access_token_expiration")]
    public DateTime AccessTokenExpiration { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}