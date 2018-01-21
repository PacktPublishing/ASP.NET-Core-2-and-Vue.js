using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
  public class Product
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Slug { get; set; }
    [Required]
    public string Thumbnail { get; set; }
    [Required]
    public string ShortDescription { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
  }
}