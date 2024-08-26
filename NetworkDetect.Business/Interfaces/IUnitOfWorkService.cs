namespace NetworkDetect.Business.Interfaces;

public interface IUnitOfWorkService
{
	IUserService UserService { get; }
	IProductService ProductService { get; }
	ICartService CartService { get; }
	IImageService ImageService { get; }
}
