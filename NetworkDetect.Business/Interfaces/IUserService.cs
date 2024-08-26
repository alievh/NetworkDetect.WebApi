using NetworkDetect.Business.DTOs.UserDTO;

namespace NetworkDetect.Business.Interfaces;

public interface IUserService
{
	Task<UserGetDto> GetAsync(string id);
}
