using Microsoft.AspNetCore.Mvc;
using NetworkDetect.Business.DTOs.CartDTO;
using NetworkDetect.Business.DTOs.StatusCode;
using NetworkDetect.Business.Interfaces;

namespace NetworkDetect.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
	private readonly IUnitOfWorkService _unitOfWorkService;

	public CartController(IUnitOfWorkService unitOfWorkService)
	{
		_unitOfWorkService = unitOfWorkService;
	}

	[HttpGet()]
	public async Task<ActionResult<CartGetDto>> CartGetAsync(int id)
	{
		try
		{
			return Ok(await _unitOfWorkService.CartService.GetAsync());
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}

	[HttpPut("addToCart/{productId}")]
	public async Task<ActionResult> AddToCartAsync(int productId)
	{
		try
		{
			await _unitOfWorkService.CartService.AddToCartAsync(productId);
			return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Product added succesfully!" });
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}

	[HttpPut("removeFromCart/{productId}")]
	public async Task<ActionResult> RemoveFromCartAsync(int productId)
	{
		try
		{
			await _unitOfWorkService.CartService.RemoveFromCartAsync(productId);
			return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Product removed succesfully!" });
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status502BadGateway, new Response { Status = "Error", Message = ex.ToString() });
		}
	}
}
