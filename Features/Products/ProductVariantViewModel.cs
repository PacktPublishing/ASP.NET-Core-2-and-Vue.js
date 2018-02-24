namespace ECommerce.Features.Products
{
  public class ProductVariantViewModel
  {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Thumbnail { get; set; }
    public int ColourId { get; set; }
    public string Colour { get; set; }
    public int StorageId { get; set; }
    public string Capacity { get; set; }
    public decimal Price { get; set; }
  }
}