using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Core.Domain.Adapters
{
    public interface IItemRepository : IBaseRepository, IRepository<Item>
    {
    }
}
