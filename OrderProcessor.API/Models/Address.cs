namespace OrderProcessor.API.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AdditionalInfo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}