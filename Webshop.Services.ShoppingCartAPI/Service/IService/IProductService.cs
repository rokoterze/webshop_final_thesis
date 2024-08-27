using Webshop.Services.ShoppingCartAPI.Models.Dto;

namespace WebShop.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
