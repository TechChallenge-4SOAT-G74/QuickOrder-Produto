using Moq;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoObterUseCaseTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoObterUseCase _produtoObterUseCase;

        public ProdutoObterUseCaseTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoObterUseCase = new ProdutoObterUseCase(_produtoRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnListOfProdutos_WhenProdutosExist()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto("Produto 1", 1, 100, "Descrição 1"),
                new Produto("Produto 2", 2, 200, "Descrição 2"),
            };

            _produtoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(produtos);

            // Act
            var result = await _produtoObterUseCase.Execute();

            // Assert
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("Produto 1", result.Data[0].Nome);
            Assert.Equal("Produto 2", result.Data[1].Nome);
        }

        [Fact]
        public async Task Execute_ShouldReturnProduto_WhenProdutoExists()
        {
            // Arrange
            var produto = new Produto("Produto 1", 1, 100, "Descrição 1");
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(1)).ReturnsAsync(produto);

            // Act
            var result = await _produtoObterUseCase.Execute(1);

            // Assert
            Assert.NotNull(result.Data);
            Assert.Equal("Produto 1", result.Data.Nome);
            Assert.Equal("Descrição 1", result.Data.Descricao);
            Assert.Equal(100, result.Data.Preco);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenExceptionIsThrownInGetAll()
        {
            // Arrange
            _produtoRepositoryMock.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _produtoObterUseCase.Execute();

            // Assert
            Assert.Null(result.Data);
            Assert.Contains("Database error", result.Errors.FirstOrDefault().Message);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenExceptionIsThrownInGetFirst()
        {
            // Arrange
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _produtoObterUseCase.Execute(1);

            // Assert
            Assert.Null(result.Data);
            Assert.Contains("Database error", result.Errors.FirstOrDefault().Message);
        }
    }
}
