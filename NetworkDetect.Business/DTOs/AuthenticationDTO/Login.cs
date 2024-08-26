using System.ComponentModel.DataAnnotations;

namespace NetworkDetect.Business.DTOs.AuthenticationDTO;

public class Login
{
	[Required]
	public string Email { get; set; }
	[Required]
	public string Password { get; set; }
}
