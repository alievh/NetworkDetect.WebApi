using NetworkDetect.Business.DTOs.ProductDTO;

namespace NetworkDetect.Business.Interfaces;

public interface IProductService
{
	Task<ProductGetDto> GetAsync(int id);
	Task<List<ProductGetDto>> GetAllAsync();
	Task CreateAsync(ProductCreateDto productCreateDto);
}
