using QuickOrder.Adapters.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Adapters.PostgresDB.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) :
            base(context)
        {
        }
    }
}
