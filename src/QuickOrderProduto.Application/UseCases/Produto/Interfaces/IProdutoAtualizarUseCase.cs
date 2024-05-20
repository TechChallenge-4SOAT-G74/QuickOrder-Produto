using QuickOrderProduto.Application.Dtos;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoAtualizarUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto, int id);
    }
}
