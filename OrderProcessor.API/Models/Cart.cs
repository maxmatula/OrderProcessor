using System.Collections.Generic;

namespace OrderProcessor.API.Models
{
    public class Cart
    {
        public int UserId;
        public IEnumerable<CartLine> Lines { get; set; }
    }
}