using QuickOrderProduto.Core.Domain;

namespace QuickOrderProduto.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
    }
}
