using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
  public class OS
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<Product> Products = new List<Product>();
  }
}