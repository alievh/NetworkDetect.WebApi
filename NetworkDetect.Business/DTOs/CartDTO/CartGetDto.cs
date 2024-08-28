using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.DTOs.CartDTO;

public class CartGetDto
{
	public ICollection<Product> Products { get; set; }
}
