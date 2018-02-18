namespace ECommerce.Features.Products
{
  public class ProductListViewModel
  {
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public string Thumbnail { get; set; }
  }
}