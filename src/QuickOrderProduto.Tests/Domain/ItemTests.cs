using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Tests.Domain
{
    public class ItemTests
    {
        [Fact]
        public void Construtor_Item_Deve_Configurar_Propriedades_Corretamente()
        {
            // Arrange and Act
            var item = new Item(1, 10, 5);

            // Assert
            Assert.Equal(1, item.TipoItem);
            Assert.Equal(10.0, item.Valor);
            Assert.Equal(5, item.QuantidadeItem);
            Assert.Null(item.ProdutoItens);
        }
    }
}