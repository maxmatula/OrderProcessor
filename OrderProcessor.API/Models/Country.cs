namespace OrderProcessor.API.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public double TaxRate { get; set; }
    }
}