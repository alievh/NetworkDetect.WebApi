using AutoMapper;
using Microsoft.AspNetCore.Http;
using NetworkDetect.Business.DTOs.CartDTO;
using NetworkDetect.Business.Exceptions;
using NetworkDetect.Business.Interfaces;
using NetworkDetect.Core;
using NetworkDetect.Core.Entities;
using System.Security.Claims;

namespace NetworkDetect.Business.Implementations;

public class CartService : ICartService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public CartService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<CartGetDto> GetAsync()
	{
		var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
		Cart cart = await _unitOfWork.CartRepository.GetAsync(n => n.AppUser.Id == userId && !n.IsDeleted, "Products.Image", "AppUser");
		if (cart is null) throw new NotFoundException("Cart not found!");
		CartGetDto cartGetDto = _mapper.Map<CartGetDto>(cart);
		return cartGetDto;
	}

	public async Task AddToCartAsync(int productId)
	{
		var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
		Product product = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == productId) ?? throw new NotFoundException("Product not found!");
		Cart cart = await _unitOfWork.CartRepository.GetAsync(n => n.AppUserId == userId && !n.IsDeleted, "Products") ?? throw new NotFoundException("Cart not found!");

		cart.Products.Add(product);
		await _unitOfWork.CartRepository.UpdateAsync(cart);
	}

	public async Task RemoveFromCartAsync(int productId)
	{
		var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
		Product product = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == productId) ?? throw new NotFoundException("Product not found!");
		Cart cart = await _unitOfWork.CartRepository.GetAsync(n => n.AppUserId == userId && !n.IsDeleted, "Products") ?? throw new NotFoundException("Cart not found!");

		cart.Products.Remove(product);
		await _unitOfWork.CartRepository.UpdateAsync(cart);
	}

	public async Task UpdateCartAsync(ICollection<Product> products)
	{
		var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
		Cart cart = await _unitOfWork.CartRepository.GetAsync(n => n.AppUserId == userId && !n.IsDeleted, "Products") ?? throw new NotFoundException("Cart not found!");

		cart.Products = products;
		await _unitOfWork.CartRepository.UpdateAsync(cart);
	}
}
