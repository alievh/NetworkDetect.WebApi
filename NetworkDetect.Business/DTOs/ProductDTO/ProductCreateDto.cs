using Microsoft.AspNetCore.Http;

namespace NetworkDetect.Business.DTOs.ProductDTO;

public class ProductCreateDto
{
	public string Title { get; set; }
	public double Price { get; set; }
	public IFormFile? ImageFile { get; set; }
}
