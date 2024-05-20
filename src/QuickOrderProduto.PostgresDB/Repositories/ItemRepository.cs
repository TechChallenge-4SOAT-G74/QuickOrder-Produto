using QuickOrder.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.PostgresDB.Core;

namespace QuickOrderProduto.PostgresDB.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
