using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.PostgresDB.Core;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Adapters.PostgresDB.Mapping
{
    public class ItemMap : IEntityMap<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.TipoItem)
                  .IsRequired();
            builder.Property(x => x.Valor)
                .IsRequired();
            builder.Property(x => x.QuantidadeItem)
                .IsRequired();
            builder.HasMany(x => x.ProdutoItens);
        }
    }
}
