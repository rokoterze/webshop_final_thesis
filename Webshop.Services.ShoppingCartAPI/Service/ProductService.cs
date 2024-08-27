using Newtonsoft.Json;
using Webshop.Services.ShoppingCartAPI.Models.Dto;
using WebShop.Services.ShoppingCartAPI.Service.IService;

namespace WebShop.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/Product/GetAllProducts");

            var apiContet = await response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (responseJson.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(responseJson.Result));
            }
            return new List<ProductDto>();
        }
    }
}
