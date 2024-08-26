using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using NetworkDetect.Business.Interfaces;
using NetworkDetect.Core;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.Implementations;

public class UnitOfWorkService : IUnitOfWorkService
{
	private IUserService _userService;
	private ICartService _cartService;
	private IProductService _productService;
	private IImageService _imageService;

	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly IHostEnvironment _hostEnvironment;
	private readonly UserManager<AppUser> _userManager;

	public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IHostEnvironment hostEnvironment)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_httpContextAccessor = httpContextAccessor;
		_userManager = userManager;
		_hostEnvironment = hostEnvironment;
	}



	public IUserService UserService => _userService ??= new UserService(_unitOfWork, _mapper);

	public ICartService CartService => _cartService ??= new CartService(_unitOfWork, _mapper, _httpContextAccessor);

	public IProductService ProductService => _productService ??= new ProductService(_unitOfWork, _mapper, _hostEnvironment);
	public IImageService ImageService => _imageService ??= new ImageService();

}
