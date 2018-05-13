using System.Collections.Generic;

namespace ECommerce.Features.Products
{
  public class CreateProductViewModel
  {
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public decimal TalkTime { get; set; }
    public decimal StandbyTime { get; set; }
    public decimal ScreenSize { get; set; }
    public string Brand { get; set; }
    public string OS { get; set; }
    public List<string> Features { get; set; }
    public List<CreateProductVariantViewModel> Variants { get; set; }
  }
}