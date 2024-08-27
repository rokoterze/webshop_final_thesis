namespace WebShop.Services.OrderAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; } = 1;
    }
}
