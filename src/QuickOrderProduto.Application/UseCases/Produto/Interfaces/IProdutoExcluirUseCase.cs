using QuickOrderProduto.Core.Application.Dtos;

namespace QuickOrderProduto.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
