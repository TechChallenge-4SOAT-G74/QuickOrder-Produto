using Microsoft.AspNetCore.Mvc;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Application.UseCases.Produto.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderProduto.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class EndpointsProdutoConfig
    {
        public static void RegisterProdutoEndpoints(this WebApplication app)
        {
            app.MapGet("/GetAll", async ([FromServices] IProdutoObterUseCase produtoObterUseCase) =>
            {
                return Results.Ok(await produtoObterUseCase.Execute());
            });

            app.MapGet("/Get", async ([FromServices] IProdutoObterUseCase produtoObterUseCase, int id) =>
            {
                var teste = await produtoObterUseCase.Execute(id);

                return Results.Ok(await produtoObterUseCase.Execute(id));
            });

            app.MapPost("/Post", async ([FromServices] IProdutoCriarUseCase produtoCriarUseCase, [FromBody] ProdutoDto produto) =>
            {
                return Results.Ok(await produtoCriarUseCase.Execute(produto));
            });

            app.MapPost("/Put", async ([FromServices] IProdutoAtualizarUseCase produtoAtualizarUseCase, [FromBody] ProdutoDto produto, int id) =>
            {
                return Results.Ok(await produtoAtualizarUseCase.Execute(produto, id));
            });

            app.MapGet("/Delete", async ([FromServices] IProdutoExcluirUseCase produtoExcluirUseCase, int id) =>
            {
                return Results.Ok(await produtoExcluirUseCase.Execute(id));
            });

            app.MapGet("/SelecionarProduto", async ([FromServices] IProdutoSelecionarUseCase produtoSelecionarUseCase, int idProduto, int idCliente) =>
            {
                return Results.Ok(await produtoSelecionarUseCase.Execute(idProduto, idCliente));
            });
        }
    }
}
