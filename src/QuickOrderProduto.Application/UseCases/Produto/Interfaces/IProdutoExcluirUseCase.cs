using QuickOrderProduto.Application.Dtos;

namespace QuickOrderProduto.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoExcluirUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
