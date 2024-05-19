using QuickOrder.Adapters.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Adapters.PostgresDB.Repositories
{
    public class ProdutoItemRepository : Repository<ProdutoItem>, IProdutoItemRepository
    {
        public ProdutoItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
