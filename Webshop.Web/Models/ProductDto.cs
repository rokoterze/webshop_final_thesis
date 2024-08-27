using System.ComponentModel.DataAnnotations;

namespace Webshop.Web.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; }

        [Range(1,100)]
        public int Count { get; set; } = 1;
    }
}
