using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ECommerce.Features.Authentication
{
  public class TokenViewModel
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
    public IEnumerable<string> Roles { get; set; }
  }
}