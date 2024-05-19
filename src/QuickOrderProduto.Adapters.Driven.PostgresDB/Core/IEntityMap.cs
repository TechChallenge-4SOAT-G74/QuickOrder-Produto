using Microsoft.EntityFrameworkCore;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrder.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
