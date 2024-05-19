using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Core.Domain.Adapters
{
    public interface IProdutoRepository : IBaseRepository, IRepository<Produto>
    {
    }
}