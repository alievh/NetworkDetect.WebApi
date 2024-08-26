using NetworkDetect.Business.DTOs.CartDTO;

namespace NetworkDetect.Business.Interfaces;

public interface ICartService
{
	Task<CartGetDto> GetAsync();
	Task AddToCartAsync(int productId);
	Task RemoveFromCartAsync(int productId);
}
