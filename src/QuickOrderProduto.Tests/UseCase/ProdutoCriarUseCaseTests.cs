using Moq;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Core.Domain.Adapters;
using QuickOrderProduto.Core.Domain.Entities;
using System.Linq.Expressions;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoCriarUseCaseTests
    {
        [Fact]
        public async Task Execute_ProdutoNaoExiste_DeveInserirProduto()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoItemRepositoryMock = new Mock<IProdutoItemRepository>();

            produtoRepositoryMock.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Produto, bool>>>()))
                .ReturnsAsync((Produto)null);

            var items = new List<Item>
            {
                new  Item(1, 5, 2)
            };

            var produtoItens = new List<ProdutoItem>
            {
                new ProdutoItem(1, 2)
            };

            produtoItens.FirstOrDefault().Item = items.FirstOrDefault();

            produtoRepositoryMock.Setup(x => x.Insert(It.IsAny<Produto>()))
                .ReturnsAsync(new Produto("Produto Teste", 1, 10, produtoItens: produtoItens));

            var useCase = new ProdutoCriarUseCase(produtoRepositoryMock.Object, produtoItemRepositoryMock.Object);
            var produtoDto = new ProdutoDto
            {
                Nome = "Produto Teste",
                Categoria = "Lanche",
                Preco = 10.0,
                Descricao = "Descrição Teste",
                Foto = "Foto Teste"
            };

            // Act
            var result = await useCase.Execute(produtoDto);

            // Assert
            Assert.True(result.IsSuccess);
            produtoRepositoryMock.Verify(x => x.Insert(It.IsAny<Produto>()), Times.Once);
        }


        [Fact]
        public async Task Execute_ProdutoJaExiste_DeveRetornarErro()
        {
            // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoItemRepositoryMock = new Mock<IProdutoItemRepository>();

            var items = new List<Item>
            {
                new  Item(1, 5, 2)
            };

            var produtoItens = new List<ProdutoItem>
            {
                new ProdutoItem(1, 2)
            };

            produtoItens.FirstOrDefault().Item = items.FirstOrDefault();

            produtoRepositoryMock.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Produto, bool>>>()))
                .ReturnsAsync(new Produto("Produto Teste", 1, 10, produtoItens: produtoItens));

            var useCase = new ProdutoCriarUseCase(produtoRepositoryMock.Object, produtoItemRepositoryMock.Object);

            var produtoDto = new ProdutoDto
            {
                Nome = "Produto Teste",
                Categoria = "Lanche",
                Preco = 10,
                Descricao = "Descrição Teste",
                Foto = "Foto Teste"
            };

            // Act
            var result = await useCase.Execute(produtoDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Produto já existe.", result.Errors.FirstOrDefault().Message);
        }

        [Fact]
        public async Task Execute_CategoriaProdutoJaIncorreta_DeveRetornarErro()
        {      // Arrange
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoItemRepositoryMock = new Mock<IProdutoItemRepository>();

            var items = new List<Item>
            {
                new  Item(1, 5, 2)
            };

            var produtoItens = new List<ProdutoItem>
            {
                new ProdutoItem(1, 2)
            };

            produtoItens.FirstOrDefault().Item = items.FirstOrDefault();

            produtoRepositoryMock.Setup(x => x.Insert(It.IsAny<Produto>()))
                .ReturnsAsync(new Produto("Produto Teste", 1, 10, produtoItens: produtoItens));

            var useCase = new ProdutoCriarUseCase(produtoRepositoryMock.Object, produtoItemRepositoryMock.Object);
            var produtoDto = new ProdutoDto
            {
                Nome = "Produto Teste",
                Categoria = "Cetegoria incorreta",
                Preco = 10.0,
                Descricao = "Descrição Teste",
                Foto = "Foto Teste"
            };

            // Act
            var result = await useCase.Execute(produtoDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains("Requested value 'Cetegoria incorreta' was not found.", result.Errors.FirstOrDefault().Message);
        }
    }
}