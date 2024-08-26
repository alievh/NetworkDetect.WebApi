using NetworkDetect.Core.Entities;
using NetworkDetect.Core.Interfaces;
using NetworkDetect.Data.DAL;

namespace NetworkDetect.Data.Implementations;

public class ImageRepository : Repository<Image>, IImageRepository
{
	private readonly AppDbContext _context;
	public ImageRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}
