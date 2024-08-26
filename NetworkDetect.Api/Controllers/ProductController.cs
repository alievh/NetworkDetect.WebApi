using Microsoft.AspNetCore.Mvc;
using NetworkDetect.Business.DTOs.ProductDTO;
using NetworkDetect.Business.DTOs.StatusCode;
using NetworkDetect.Business.Interfaces;

namespace NetworkDetect.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IUnitOfWorkService _unitOfWorkService;

	public ProductController(IUnitOfWorkService unitOfWorkService)
	{
		_unitOfWorkService = unitOfWorkService;
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ProductGetDto>> ProductGetAsync(int id)
	{
		try
		{
			return Ok(await _unitOfWorkService.ProductService.GetAsync(id));
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}

	[HttpGet]
	public async Task<ActionResult<List<ProductGetDto>>> ProductGetAllAsync()
	{
		try
		{
			return Ok(await _unitOfWorkService.ProductService.GetAllAsync());
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}

	[HttpPost("ProductCreate")]
	public async Task<ActionResult> ProductCreateAsync([FromForm] ProductCreateDto productCreateDto)
	{
		try
		{
			await _unitOfWorkService.ProductService.CreateAsync(productCreateDto);
			return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Product created succesfully!" });
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}
}
