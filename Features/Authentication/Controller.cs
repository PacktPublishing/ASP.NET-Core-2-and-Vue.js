using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Features.Authentication
{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    private readonly EcommerceContext _db;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public TokenController(EcommerceContext db, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
    {
      _db = db;
      _signInManager = signInManager;
      _userManager = userManager;
      _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> GetToken([FromBody] LoginViewModel model)
    {
      var errorMessage = "Invalid e-mail address and/or password";

      if (!ModelState.IsValid)
        return BadRequest(errorMessage);

      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        return BadRequest(errorMessage);

      if (await _userManager.IsLockedOutAsync(user))
        return BadRequest(errorMessage);

      var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

      if (!result.Succeeded)
        return BadRequest(errorMessage);

      var token = await GenerateToken(user);

      return Ok(token);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refreshtoken([FromBody] RefreshTokenViewModel model)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var user = await _db.Users.SingleOrDefaultAsync(x => x.RefreshToken == model.RefreshToken);

      if (user == null)
        return BadRequest();

      var token = await GenerateToken(user);

      return Ok(token);
    }

    private async Task<TokenViewModel> GenerateToken(AppUser user)
    {
      var claims = new List<Claim>
      {
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
          new Claim(ClaimTypes.Name, user.UserName)
      };

      var roles = await _userManager.GetRolesAsync(user);
      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Authentication:JwtExpireMins"]));

      var token = new JwtSecurityToken(
        _configuration["Authentication:JwtIssuer"],
        _configuration["Authentication:JwtAudience"],
        claims,
        expires: expires,
        signingCredentials: creds
      );

      var refreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

      user.RefreshToken = refreshToken;
      await _userManager.UpdateAsync(user);

      return new TokenViewModel
      {
        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
        RefreshToken = refreshToken,
        Roles = roles,
        FirstName = user.FirstName,
        LastName = user.LastName
      };
    }
  }
}