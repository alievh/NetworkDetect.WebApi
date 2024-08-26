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

	public UnitOfWork(AppDbContext context, ICartRepository cartRepository, IProductRepository productRepository)
	{
		_context = context;
		_cartRepository = cartRepository;
		_productRepository = productRepository;
	}

	public ICartRepository CartRepository => _cartRepository ??= new CartRepository(_context);

	public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
}
