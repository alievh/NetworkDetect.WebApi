using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.DTOs.UserDTO;

public class UserGetDto
{
	public string? Id { get; set; }
	public string? Firstname { get; set; }
	public string? Lastname { get; set; }
	public string? Email { get; set; }

	public Cart Cart { get; set; }
}
