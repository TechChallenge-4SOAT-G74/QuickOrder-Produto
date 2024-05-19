﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using QuickOrder.Adapters.PostgresDB.Core;

#nullable disable

namespace QuickOrderProduto.Adapters.PostgresDB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240423143939_dados-iniciais")]
    partial class dadosiniciais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuantidadeItem")
                        .HasColumnType("integer");

                    b.Property<int>("TipoItem")
                        .HasColumnType("integer");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Foto")
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.ProdutoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer")
                        .HasColumnName("Item");

                    b.Property<bool>("PermitidoAlterar")
                        .HasColumnType("boolean");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("Produto");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeMax")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeMin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoItem");
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.Produto", b =>
                {
                    b.OwnsOne("QuickOrderProduto.Domain.ValueObjects.NomeVo", "Nome", b1 =>
                        {
                            b1.Property<int>("ProdutoId")
                                .HasColumnType("integer");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Nome");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.Navigation("Nome")
                        .IsRequired();
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.ProdutoItem", b =>
                {
                    b.HasOne("QuickOrderProduto.Domain.Entities.Item", "Item")
                        .WithMany("ProdutoItens")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("QuickOrderProduto.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutoItens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.Item", b =>
                {
                    b.Navigation("ProdutoItens");
                });

            modelBuilder.Entity("QuickOrderProduto.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutoItens");
                });
#pragma warning restore 612, 618
        }
    }
}
