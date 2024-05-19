using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Core.Domain.Adapters
{
    public interface IProdutoItemRepository : IBaseRepository, IRepository<ProdutoItem>
    {
    }
}