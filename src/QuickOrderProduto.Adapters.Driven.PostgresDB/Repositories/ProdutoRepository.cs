using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrderProduto.Core.Domain.Adapters;
using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Adapters.Driven.PostgresDB.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) :
            base(context)
        {
        }
    }
}
