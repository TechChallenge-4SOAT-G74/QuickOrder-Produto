using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<ProdutoDto>>> Execute();
        Task<ServiceResult<ProdutoDto>> Execute(int id);
    }
}
