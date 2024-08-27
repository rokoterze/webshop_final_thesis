namespace WebShop.Services.ProductAPI.Models.Dto
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; }
    }
}
