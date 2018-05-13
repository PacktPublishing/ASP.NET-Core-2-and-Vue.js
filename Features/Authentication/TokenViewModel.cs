using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ECommerce.Features.Authentication
{
  public class TokenViewModel
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("access_token_expiration")]
    public DateTime AccessTokenExpiration { get; set; }
    public IEnumerable<string> Roles { get; set; }
  }
}