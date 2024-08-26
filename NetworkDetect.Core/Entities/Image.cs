using NetworkDetect.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NetworkDetect.Core.Entities;

public class Image : IEntity
{
	public int Id { get; set; }

	[Required]
	public string ImageUrl { get; set; }
	public int? ProductId { get; set; }
	public Product? Product { get; set; }
}
