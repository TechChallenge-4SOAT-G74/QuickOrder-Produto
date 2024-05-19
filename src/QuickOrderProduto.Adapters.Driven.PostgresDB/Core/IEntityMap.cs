using Microsoft.EntityFrameworkCore;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrder.Adapters.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
