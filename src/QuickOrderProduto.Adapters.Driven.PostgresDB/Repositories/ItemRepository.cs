using QuickOrder.Adapters.PostgresDB.Core;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Adapters.PostgresDB.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
