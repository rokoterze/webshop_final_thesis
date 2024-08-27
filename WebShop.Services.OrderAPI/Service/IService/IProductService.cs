using WebShop.Services.OrderAPI.Models.Dto;

namespace WebShop.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
