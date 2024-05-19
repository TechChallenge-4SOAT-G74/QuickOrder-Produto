using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
