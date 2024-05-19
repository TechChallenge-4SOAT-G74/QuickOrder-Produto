using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Domain
{
    public interface IItemRepository : IBaseRepository, IRepository<Item>
    {
    }
}
