using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
  public class Feature
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<ProductFeature> ProductFeatures { get; set; } = new List<ProductFeature>();
  }
}