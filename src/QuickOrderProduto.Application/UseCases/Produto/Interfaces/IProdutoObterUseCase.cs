﻿using QuickOrderProduto.Application.Dtos;

namespace QuickOrderProduto.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<ProdutoDto>>> Execute();
        Task<ServiceResult<ProdutoDto>> Execute(int id);
    }
}
