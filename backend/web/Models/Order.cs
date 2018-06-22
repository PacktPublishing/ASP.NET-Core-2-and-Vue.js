using System.Collections.Generic;

namespace backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}