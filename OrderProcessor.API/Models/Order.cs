using System.Collections.Generic;

namespace OrderProcessor.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int CurrencyId { get; set; }
        public int ProductsTotalNumber { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal Tax { get; set; }
        public decimal PriceWithoutTax { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}