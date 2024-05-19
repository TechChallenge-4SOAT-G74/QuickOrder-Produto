using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Domain
{
    public interface IProdutoItemRepository : IBaseRepository, IRepository<ProdutoItem>
    {
    }
}