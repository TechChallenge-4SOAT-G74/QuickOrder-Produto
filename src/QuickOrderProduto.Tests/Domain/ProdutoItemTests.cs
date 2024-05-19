using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Tests.Domain
{
    public class ProdutoItemTests
    {
        [Fact]
        public void Construtor_ProdutoItem_Deve_Configurar_Propriedades_Corretamente()
        {
            // Arrange and Act
            var produtoItem = new ProdutoItem(1, 2);

            // Assert
            Assert.Equal(1, produtoItem.ProdutoId);
            Assert.Equal(2, produtoItem.Quantidade);
            Assert.Null(produtoItem.ItemId);
            Assert.Null(produtoItem.Item);
            Assert.Equal(0, produtoItem.QuantidadeMin);
            Assert.Equal(0, produtoItem.QuantidadeMax);
            Assert.False(produtoItem.PermitidoAlterar);
        }
    }
}