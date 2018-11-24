using System.Collections.Generic;

namespace OrderProcessor.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Address> Address { get; set; }

    }
}