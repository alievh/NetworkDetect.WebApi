using NetworkDetect.Core.Interfaces;

namespace NetworkDetect.Core;

public interface IUnitOfWork
{
	ICartRepository CartRepository { get; }
	IProductRepository ProductRepository { get; }
	IUserRepository UserRepository { get; }
	IImageRepository ImageRepository { get; }
	Task SaveAsync();
}
