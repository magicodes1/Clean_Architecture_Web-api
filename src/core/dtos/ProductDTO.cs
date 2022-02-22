namespace Delicious.core
{
    public class ProductDTO : DTO
    {
        public override int id { get; set; }
        public string ProductName { get; set; } = "";
        public string UrlShortName { get; set; } = "";
        public int Price { get; set; }

        public int Sale { get; set; }

        public string Describe { get; set; } = "";

        public string Images { get; set; } = "";

        public int CategoryId { get; set; }
    }
}