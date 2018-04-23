namespace ECommerce.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int ColourId { get; set; }
    public int StorageId { get; set; }
    public int Quantity { get; set; }

    public ProductVariant ProductVariant { get; set; }
  }
}