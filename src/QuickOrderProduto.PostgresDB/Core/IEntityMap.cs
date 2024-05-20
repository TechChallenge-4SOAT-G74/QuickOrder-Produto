using Microsoft.EntityFrameworkCore;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
