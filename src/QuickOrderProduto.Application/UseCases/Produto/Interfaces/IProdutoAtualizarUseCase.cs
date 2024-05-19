using QuickOrderProduto.Core.Application.Dtos;

namespace QuickOrderProduto.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto, int id);
    }
}
