using QuickOrderProduto.Application.Dtos;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoObterUseCase
    {
        Task<ServiceResult<List<ProdutoDto>>> Execute();
        Task<ServiceResult<ProdutoDto>> Execute(int id);
    }
}
