using QuickOrderProduto.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.PostgresDB.Core;

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
