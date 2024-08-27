using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Services.ProductAPI.Data;
using WebShop.Services.ProductAPI.Models;
using WebShop.Services.ProductAPI.Models.Dto;

namespace WebShop.Services.ProductAPI.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;

        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet("GetAllProducts")]
        public async Task<ResponseDto> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> productList = await _db.Product.ToListAsync();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(productList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetProductById")]
        public async Task<ResponseDto> GetProductById(int id)
        {
            try
            {
                var product = await _db.Product.FirstOrDefaultAsync(x => x.ProductId == id);

                if (product != null)
                {
                    _response.Result = _mapper.Map<ProductDto>(product);
                }

                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Product not found";
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("CreateProduct")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> CreateProduct([FromBody] CreateProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _db.Product.AddAsync(product);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<CreateProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("CreateProducts")]
        public async Task<ResponseDto> CreateProducts([FromBody] List<CreateProductDto> productDtos)
        {
            try
            {
                var products = _mapper.Map<IEnumerable<Product>>(productDtos);

                await _db.Product.AddRangeAsync(products);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<IEnumerable<CreateProductDto>>(products);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                _db.Product.Update(product);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                
            }
            return _response;
        }

        [HttpDelete("DeleteProduct")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteProduct(int id)
        {
            try
            {
                var product = await _db.Product.FirstOrDefaultAsync(x => x.ProductId == id);

                if (product != null)
                {
                    _db.Product.Remove(product);
                    await _db.SaveChangesAsync();
                    return _response;
                }

                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Product not found";

                    return _response;
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return _response;
            }
        }
    }
}
