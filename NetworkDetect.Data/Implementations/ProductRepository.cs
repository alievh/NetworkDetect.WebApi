using NetworkDetect.Core.Entities;
using NetworkDetect.Core.Interfaces;
using NetworkDetect.Data.DAL;

namespace NetworkDetect.Data.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly AppDbContext? _context;

	public ProductRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}
