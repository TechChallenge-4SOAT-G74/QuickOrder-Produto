﻿namespace QuickOrderProduto.Core.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
    }
}
