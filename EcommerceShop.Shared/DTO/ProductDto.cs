namespace EcommerceShop.Shared.DTO
{
    public class ProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }
        public string CategoryId { get; set; }
        public string NameCategory { get; set; }
        public int Rating { get; set; }
    }
}
