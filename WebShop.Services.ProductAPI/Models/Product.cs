using System.ComponentModel.DataAnnotations;

namespace WebShop.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; } = 0;
        public string? ImageURL { get; set; }
        public string? Description { get; set; }
    }
}
