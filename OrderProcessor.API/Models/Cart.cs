using System.Collections.Generic;

namespace OrderProcessor.API.Models
{
    public class Cart
    {
        public int UserId;
        public int AddressId;
        public int CurrencyId;
        public List<CartLine> Lines { get; set; }
    }
}