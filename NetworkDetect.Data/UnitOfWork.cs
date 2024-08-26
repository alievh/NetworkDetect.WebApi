using NetworkDetect.Core;
using NetworkDetect.Core.Interfaces;
using NetworkDetect.Data.DAL;
using NetworkDetect.Data.Implementations;

namespace NetworkDetect.Data;


public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _context;
	private ICartRepository _cartRepository;
	private IProductRepository _productRepository;
	private IUserRepository _userRepository;
	private IImageRepository _imageRepository;

	public UnitOfWork(AppDbContext context)
	{
		_context = context;
	}

	public ICartRepository CartRepository => _cartRepository ??= new CartRepository(_context);
	public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
	public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
	public IImageRepository ImageRepository => _imageRepository ??= new ImageRepository(_context);

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
}
