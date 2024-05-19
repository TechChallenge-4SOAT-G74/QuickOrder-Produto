using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrderProduto.Core.Domain.Adapters;
using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Adapters.Driven.PostgresDB.Repositories
{
    public class ProdutoItemRepository : Repository<ProdutoItem>, IProdutoItemRepository
    {
        public ProdutoItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
