using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrderProduto.Core.Domain.Adapters;
using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Adapters.Driven.PostgresDB.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
