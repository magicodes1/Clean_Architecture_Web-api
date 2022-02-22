namespace Delicious.core
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = "";
        public string UrlShortName { get; set; } = "";
        public int Price { get; set; }

        public int Sale { get; set; }

        public string Describe { get; set; } = "";

        public string Images { get; set; } = "";

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}