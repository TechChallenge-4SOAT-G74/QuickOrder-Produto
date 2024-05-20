using Moq;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoExcluirUseCaseTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoExcluirUseCase _produtoExcluirUseCase;

        public ProdutoExcluirUseCaseTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoExcluirUseCase = new ProdutoExcluirUseCase(_produtoRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ProdutoExiste_DeveExcluirProduto()
        {
            // Arrange
            int produtoId = 1;
            var produto = new Produto("Produto Teste", 1, 10, "Descrição Teste");
 
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(produtoId))
                                  .ReturnsAsync(produto);
            _produtoRepositoryMock.Setup(repo => repo.Delete(produtoId))
                                  .Returns(Task.CompletedTask);

            // Act
            var result = await _produtoExcluirUseCase.Execute(produtoId);

            // Assert
            Assert.False(result.Errors.Any());
            _produtoRepositoryMock.Verify(repo => repo.GetFirst(produtoId), Times.Once);
            _produtoRepositoryMock.Verify(repo => repo.Delete(produtoId), Times.Once);
        }

        [Fact]
        public async Task Execute_RepositoryLancaExcecao_DeveRetornarErro()
        {
            // Arrange
            int produtoId = 1;
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(produtoId))
                                  .ThrowsAsync(new Exception("Erro no repositório"));

            // Act
            var result = await _produtoExcluirUseCase.Execute(produtoId);

            // Assert
            Assert.True(result.Errors.Any());
            Assert.Contains("Erro no repositório", result.Errors.FirstOrDefault().Message);
            _produtoRepositoryMock.Verify(repo => repo.GetFirst(produtoId), Times.Once);
            _produtoRepositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}
