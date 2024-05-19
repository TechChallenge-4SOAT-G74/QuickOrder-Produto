using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Tests.Domain
{
    public class ProdutoTests
    {
        [Fact]
        public void Preco_Deve_Ser_Atualizado_Corretamente_Ao_Validar_Preco()
        {
            // Arrange
            var items = new List<Item>
            {
                new  Item(1, 5, 2)
            };

            var produtoItens = new List<ProdutoItem>
            {
                new ProdutoItem(1, 2)
            };

            produtoItens.FirstOrDefault().Item = items.FirstOrDefault();

            var produto = new Produto("Produto Teste", 1, 10, produtoItens: produtoItens);

            // Act
            produto.ValidaPreco();

            // Assert
            Assert.Equal(10, produto.Preco);
        }
    }
}