﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.PostgresDB.Core;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderProduto.PostgresDB.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ProdutoMap : IEntityMap<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.OwnsOne(x => x.Nome, nome =>
            {
                nome.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(150)")
                .IsRequired(true);
            });

            builder.Property(x => x.CategoriaId)
                   .IsRequired();
            builder.Property(x => x.Preco)
                  .IsRequired();
            builder.Property(x => x.Descricao)
                  .IsRequired(false);
            builder.Property(x => x.Foto)
                  .IsRequired(false);
            builder.HasMany(x => x.ProdutoItens);


        }
    }
}
