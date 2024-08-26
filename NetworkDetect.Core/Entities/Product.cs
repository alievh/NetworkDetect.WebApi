using NetworkDetect.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NetworkDetect.Core.Entities;

public class Product : BaseEntity, IEntity
{
	[Required]
	public string Title { get; set; }

	[Required]
	public double Price { get; set; }

	public int ImageId { get; set; }
	public Image Image { get; set; }

	public ICollection<Cart> Carts { get; set; }
}
