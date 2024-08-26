using NetworkDetect.Core.Interfaces;

namespace NetworkDetect.Core;

public interface IUnitOfWork
{
	ICartRepository CartRepository { get; }
	IProductRepository ProductRepository { get; }
	Task SaveAsync();
}
