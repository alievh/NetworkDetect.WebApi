using NetworkDetect.Core.Entities.Base;

namespace NetworkDetect.Core.Entities;

public class Cart : BaseEntity, IEntity
{
	public ICollection<Product> Products { get; set; }
}
