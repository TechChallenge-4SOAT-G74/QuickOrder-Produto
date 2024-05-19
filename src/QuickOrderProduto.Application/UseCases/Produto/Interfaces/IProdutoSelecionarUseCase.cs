using QuickOrderProduto.Application.Dtos;

namespace QuickOrderProduto.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoSelecionarUseCase
    {
        Task<ServiceResult> Execute(int idProduto, int idCliente);
    }
}
