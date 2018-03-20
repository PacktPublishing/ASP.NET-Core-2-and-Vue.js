using System.Threading.Tasks;
using ECommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Features.Users
{
  [Authorize]
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    private readonly EcommerceContext _db;

    public UsersController(EcommerceContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _db.Users.ToListAsync());
    }
  }
}
