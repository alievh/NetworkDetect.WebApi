namespace NetworkDetect.Business.Interfaces;

public interface IUnitOfWorkService
{
	IProductService ProductService { get; }
	ICartService CartService { get; }
}
