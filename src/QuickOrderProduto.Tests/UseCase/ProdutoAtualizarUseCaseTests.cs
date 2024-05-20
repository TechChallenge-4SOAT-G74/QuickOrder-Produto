using Moq;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoAtualizarUseCaseTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IProdutoItemRepository> _produtoItemRepositoryMock;
        private readonly ProdutoAtualizarUseCase _produtoAtualizarUseCase;

        public ProdutoAtualizarUseCaseTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoItemRepositoryMock = new Mock<IProdutoItemRepository>();
            _produtoAtualizarUseCase = new ProdutoAtualizarUseCase(_produtoRepositoryMock.Object, _produtoItemRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenProdutoNotFound()
        {
            // Arrange
            var produtoDto = new ProdutoDto { Nome = "Produto Teste", Categoria = "Categoria1", Preco = 10.0 };
            int produtoId = 1;

            _produtoRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ReturnsAsync((Produto)null);

            // Act
            var result = await _produtoAtualizarUseCase.Execute(produtoDto, produtoId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Any());
            Assert.Contains("Produto não encontrado.", result.Errors.FirstOrDefault().Message);
        }

        [Fact]
        public async Task Execute_ShouldHandleException_WhenRepositoryThrowsException()
        {
            // Arrange
            var produtoDto = new ProdutoDto { Nome = "Produto Teste", Categoria = "Categoria1", Preco = 10.0 };
            int produtoId = 1;

            _produtoRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _produtoAtualizarUseCase.Execute(produtoDto, produtoId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Any());
            Assert.Contains("Database error", result.Errors.FirstOrDefault().Message);
        }
    }
}