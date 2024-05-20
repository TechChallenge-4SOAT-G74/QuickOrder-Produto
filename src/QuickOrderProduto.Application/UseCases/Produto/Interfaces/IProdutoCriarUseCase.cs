using QuickOrderProduto.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoCriarUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto);
    }
}
