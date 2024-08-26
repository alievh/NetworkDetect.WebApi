using NetworkDetect.Core.Entities.Base;

namespace NetworkDetect.Core.Entities;

public class Cart : BaseEntity, IEntity
{
	public ICollection<Product> Products { get; set; }

	public string AppUserId { get; set; }
	public AppUser AppUser { get; set; }
}
