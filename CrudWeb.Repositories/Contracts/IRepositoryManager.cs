namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductRepository { get;  }

    void Save();
}