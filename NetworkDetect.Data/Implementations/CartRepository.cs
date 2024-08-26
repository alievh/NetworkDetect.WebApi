using NetworkDetect.Core.Entities;
using NetworkDetect.Core.Interfaces;
using NetworkDetect.Data.DAL;

namespace NetworkDetect.Data.Implementations;

public class CartRepository : Repository<Cart>, ICartRepository
{
	private readonly AppDbContext? _context;

	public CartRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}
