using QuickOrder.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.PostgresDB.Core;

namespace QuickOrderProduto.PostgresDB.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) :
            base(context)
        {
        }
    }
}
