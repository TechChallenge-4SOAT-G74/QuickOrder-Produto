using QuickOrder.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.PostgresDB.Repositories
{
    public class ProdutoItemRepository : Repository<ProdutoItem>, IProdutoItemRepository
    {
        public ProdutoItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
