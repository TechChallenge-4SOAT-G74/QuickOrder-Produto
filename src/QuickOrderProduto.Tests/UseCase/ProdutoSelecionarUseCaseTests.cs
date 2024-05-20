using Moq;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.Infra.MQ;

namespace QuickOrderProduto.Tests.UseCase
{
    public class ProdutoSelecionarUseCaseTests
    {
        private readonly ProdutoSelecionarUseCase _produtoSelecionarUseCase;
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IRabbitMqPub<ProdutoSelecionadoDto>> _rabbitMqPubMock;

        public ProdutoSelecionarUseCaseTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _rabbitMqPubMock = new Mock<IRabbitMqPub<ProdutoSelecionadoDto>>();
            _produtoSelecionarUseCase = new ProdutoSelecionarUseCase(_produtoRepositoryMock.Object, _rabbitMqPubMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenProdutoNotFound()
        {
            // Arrange  
            int idProduto = 1;
            int idCliente = 1;
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(idProduto)).ReturnsAsync((Produto)null);

            // Act
            var result = await _produtoSelecionarUseCase.Execute(idProduto, idCliente);

            // Assert
            Assert.True(result.Errors.Any());
            Assert.Contains("Produto não localizado.", result.Errors.FirstOrDefault().Message);
        }

        [Fact]
        public async Task Execute_ShouldPublishProdutoSelecionado_WhenProdutoFound()
        {
            // Arrange
            int idProduto = 1;
            int idCliente = 1;
            var produto = new Produto("Produto 1", 1, 100, "Descrição 1");
            produto.Id = idProduto;


            _produtoRepositoryMock.Setup(repo => repo.GetFirst(idProduto)).ReturnsAsync(produto);

            // Act
            var result = await _produtoSelecionarUseCase.Execute(idProduto, idCliente);

            // Assert
            Assert.False(result.Errors.Any());
            _rabbitMqPubMock.Verify(pub => pub.Publicar(It.Is<ProdutoSelecionadoDto>(dto =>
                dto.IdProduto == idProduto &&
                dto.IdCliente == idCliente &&
                dto.DescricaoProduto == produto.Descricao), "Produto", "Produto_Selecionado"), Times.Once);
        }

        [Fact]
        public async Task Execute_ShouldGenerateRandomIdCliente_WhenIdClienteIsZero()
        {
            // Arrange
            int idProduto = 1;
            int idCliente = 0;
            var produto = new Produto("Produto 1", 1, 100, "Descrição 1");
            produto.Id = idProduto;

            _produtoRepositoryMock.Setup(repo => repo.GetFirst(idProduto)).ReturnsAsync(produto);

            // Act
            var result = await _produtoSelecionarUseCase.Execute(idProduto, idCliente);

            // Assert
            Assert.False(result.Errors.Any());
            _rabbitMqPubMock.Verify(pub => pub.Publicar(It.Is<ProdutoSelecionadoDto>(dto =>
                dto.IdProduto == idProduto &&
                dto.IdCliente != 0 &&
                dto.DescricaoProduto == produto.Descricao), "Produto", "Produto_Selecionado"), Times.Once);
        }

        [Fact]
        public async Task Execute_ShouldReturnError_WhenExceptionIsThrown()
        {
            // Arrange
            int idProduto = 1;
            int idCliente = 1;
            _produtoRepositoryMock.Setup(repo => repo.GetFirst(idProduto)).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _produtoSelecionarUseCase.Execute(idProduto, idCliente);

            // Assert
            Assert.True(result.Errors.Any());
            Assert.Contains("Database error", result.Errors.FirstOrDefault().Message);
        }
    }
}
