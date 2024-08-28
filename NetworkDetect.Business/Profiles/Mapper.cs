using AutoMapper;
using NetworkDetect.Business.DTOs.CartDTO;
using NetworkDetect.Business.DTOs.ProductDTO;
using NetworkDetect.Business.DTOs.UserDTO;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Business.Profiles;

public class Mapper : Profile
{
	public Mapper()
	{
		CreateMap<AppUser, UserGetDto>();
		CreateMap<Cart, CartGetDto>();
		CreateMap<Product, ProductGetDto>()
			.ForMember(c => c.ImageUrl, c => c.MapFrom(src => src.Image.ImageUrl));
		CreateMap<ProductCreateDto, Product>();
	}
}

