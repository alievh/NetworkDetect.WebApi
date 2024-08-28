using NetworkDetect.Business.DTOs.CartDTO;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.Interfaces;

public interface ICartService
{
	Task<CartGetDto> GetAsync();
	Task AddToCartAsync(int productId);
	Task RemoveFromCartAsync(int productId);
	Task UpdateCartAsync(ICollection<Product> products);
}
