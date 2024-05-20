using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.PostgresDB.Core;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderProduto.PostgresDB.Mapping
{
    [ExcludeFromCodeCoverage]
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
