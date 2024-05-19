﻿using Microsoft.EntityFrameworkCore;
using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
