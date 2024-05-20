using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoUseCaseTests
    {
        [Fact]
        public void ProdutoItens_ShouldReturnListOfProdutoItem()
        {
            // Arrange
            var dto = new List<ProdutoItemDto>
        {
            new ProdutoItemDto
            {
                Item = new ItemDto { TipoItem = "Tipo 1", QuantidadeItem = 10, Valor = 100.00 },
                Quantidade = 5,
                QuantidadeMin = 1,
                QuantidadeMax = 10,
                PermitidoAlterar = true
            }
        };
            int produtoId = 1;

            // Act
            var result = ProdutoUseCaseWrapper.ProdutoItens(dto, produtoId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(produtoId, result[0].ProdutoId);
            Assert.Equal(dto[0].Quantidade, result[0].Quantidade);
            Assert.Equal(dto[0].QuantidadeMin, result[0].QuantidadeMin);
            Assert.Equal(dto[0].QuantidadeMax, result[0].QuantidadeMax);
            Assert.Equal(dto[0].PermitidoAlterar, result[0].PermitidoAlterar);
        }
    }

    public class ProdutoUseCaseWrapper : ProdutoUseCase
    {
        public static List<ProdutoItem> ProdutoItens(List<ProdutoItemDto> dto, int produtoId)
        {
            return ProdutoUseCase.ProdutoItens(dto, produtoId);
        }

        public static List<ProdutoItemDto> ProdutoItensDto(List<ProdutoItem> obj)
        {
            return ProdutoUseCase.ProdutoItensDto(obj);
        }
    }
}
