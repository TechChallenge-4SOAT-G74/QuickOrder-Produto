using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoAtualizarUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto, int id);
    }
}
