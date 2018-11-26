using System.Collections.Generic;

namespace OrderProcessor.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public int UserId { get; set; }
    }
}