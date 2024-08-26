using NetworkDetect.Core.Entities;
using NetworkDetect.Core.Interfaces;
using NetworkDetect.Data.DAL;

namespace NetworkDetect.Data.Implementations;

public class UserRepository : Repository<AppUser>, IUserRepository
{
	private readonly AppDbContext? _context;

	public UserRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}
