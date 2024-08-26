using Microsoft.AspNetCore.Identity;
using NetworkDetect.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NetworkDetect.Core.Entities;

public class AppUser : IdentityUser, IEntity
{
	[Required]
	public string Firstname { get; set; }
	[Required]
	public string Lastname { get; set; }
	public DateTime RegisterDate { get; set; }

	public Cart Cart { get; set; }
}
