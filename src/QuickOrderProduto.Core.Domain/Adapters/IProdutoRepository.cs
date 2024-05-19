using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Domain
{
    public interface IProdutoRepository : IBaseRepository, IRepository<Produto>
    {
    }
}