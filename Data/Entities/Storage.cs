using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
  public class Storage
  {
    public int Id { get; set; }
    [Required]
    public string Capacity { get; set; }

    public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
  }
}