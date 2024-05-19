using QuickOrderProduto.Core.Application.Dtos;
using QuickOrderProduto.Core.Application.UseCases;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto);
    }
}
