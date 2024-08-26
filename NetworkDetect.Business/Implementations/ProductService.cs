using AutoMapper;
using Microsoft.Extensions.Hosting;
using NetworkDetect.Business.DTOs.ProductDTO;
using NetworkDetect.Business.Exceptions;
using NetworkDetect.Business.Helpers;
using NetworkDetect.Business.Interfaces;
using NetworkDetect.Core;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.Implementations;

public class ProductService : IProductService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IHostEnvironment _hostEnvironment;

	public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHostEnvironment hostEnvironment)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_hostEnvironment = hostEnvironment;
	}

	public async Task<ProductGetDto> GetAsync(int id)
	{
		Product product = await _unitOfWork.ProductRepository.GetAsync(n => n.Id == id && !n.IsDeleted, "Image") ?? throw new NotFoundException("Product not found!");
		ProductGetDto productGetDto = _mapper.Map<ProductGetDto>(product);
		return productGetDto;
	}

	public async Task<List<ProductGetDto>> GetAllAsync()
	{
		List<Product> products = await _unitOfWork.ProductRepository.GetAllAsync(n => n.CreateDate, n => !n.IsDeleted, "Image");
		List<ProductGetDto> productGetDtos = _mapper.Map<List<ProductGetDto>>(products);
		return productGetDtos;
	}

	public async Task CreateAsync(ProductCreateDto productCreateDto)
	{
		Product product = _mapper.Map<Product>(productCreateDto);

		var image = new Image
		{
			ImageUrl = await productCreateDto.ImageFile.FileSaveAsync(_hostEnvironment.ContentRootPath, "Images")
		};

		await _unitOfWork.ImageRepository.CreateAsync(image);
		product.CreateDate = DateTime.UtcNow.AddHours(4);
		product.Image = image;
		await _unitOfWork.ProductRepository.CreateAsync(product);
	}
}
