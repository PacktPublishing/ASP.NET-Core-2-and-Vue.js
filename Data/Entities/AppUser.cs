using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Data.Entities
{
  public class AppUser : IdentityUser<int>
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped]
    public string FullName
    {
      get { return $"{FirstName} {LastName}"; }
    }

    public List<Order> Orders { get; set; } = new List<Order>();
  }
}