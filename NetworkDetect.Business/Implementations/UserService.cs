using AutoMapper;
using NetworkDetect.Business.DTOs.UserDTO;
using NetworkDetect.Business.Exceptions;
using NetworkDetect.Business.Interfaces;
using NetworkDetect.Core;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.Implementations;

public class UserService : IUserService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UserService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<UserGetDto> GetAsync(string id)
	{
		AppUser appUser = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id, "Cart");
		if (appUser is null) throw new NotFoundException("User not found!");
		UserGetDto userDto = _mapper.Map<UserGetDto>(appUser);
		return userDto;
	}
}
