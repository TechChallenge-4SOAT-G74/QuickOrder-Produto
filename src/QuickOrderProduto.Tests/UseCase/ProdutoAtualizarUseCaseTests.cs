using Moq;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Core.Domain.Adapters;
using QuickOrderProduto.Core.Domain.Entities;

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

        //[Fact]
        //public async Task Execute_ShouldUpdateProduto_WhenProdutoFound()
        //{
        //    // Arrange
        //    var produtoDto = new ProdutoDto
        //    {
        //        Nome = "Produto Atualizado",
        //        Categoria = "Categoria1",
        //        Preco = 20.0,
        //        Descricao = "Descricao Atualizada",
        //        Foto = "Foto Atualizada",
        //        ProdutoItens = new List<ProdutoItemDto>
        //    {
        //        new ProdutoItemDto { Nome = "Item1", Quantidade = 1 },
        //        new ProdutoItemDto { Nome = "Item2", Quantidade = 2 }
        //    }
        //    };

        //    int produtoId = 1;

        //    var existingProduto = new Produto
        //    {
        //        Id = produtoId,
        //        Nome = new NomeVo("Produto Antigo"),
        //        CategoriaId = (int)ECategoria.Categoria1,
        //        Preco = 10.0,
        //        Descricao = "Descricao Antiga",
        //        Foto = "Foto Antiga"
        //    };

        //    _produtoRepositoryMock.Setup(repo => repo.GetFirst(It.IsAny<int>())).ReturnsAsync(existingProduto);
        //    _produtoRepositoryMock.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.CompletedTask);
        //    _produtoItemRepositoryMock.Setup(repo => repo.Insert(It.IsAny<IEnumerable<ProdutoItem>>())).Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _produtoAtualizarUseCase.Execute(produtoDto, produtoId);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.False(result.Errors.Any());
        //    _produtoRepositoryMock.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
        //    _produtoItemRepositoryMock.Verify(repo => repo.Insert(It.IsAny<IEnumerable<ProdutoItem>>()), Times.Once);
        //}

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