using QuickOrderProduto.Application.Dtos;
using QuickOrderProduto.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Domain.Enums;
using QuickOrderProduto.Infra.MQ;

namespace QuickOrderProduto.Core.Application.UseCases.Produto
{
    public class ProdutoSelecionarUseCase : IProdutoSelecionarUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRabbitMqPub<ProdutoSelecionadoDto> _rabbitMqPub;

        public ProdutoSelecionarUseCase(IProdutoRepository produtoRepository, IRabbitMqPub<ProdutoSelecionadoDto> rabbitMqPub)
        {
            _produtoRepository = produtoRepository;
            _rabbitMqPub = rabbitMqPub;
        }

        public async Task<ServiceResult> Execute(int idProduto, int idCliente)
        {
            var result = new ServiceResult();

            try
            {
                var produto = await _produtoRepository.GetFirst(idProduto);

                if (produto == null)
                {
                    result.AddError("Produto não localizado.");
                    return result;
                }
                else
                {
                    ProdutoSelecionadoDto produtoSelecionadoDto = new ProdutoSelecionadoDto()
                    {
                        IdProduto = produto.Id,
                        IdCliente = idCliente == 0 ? new Random().Next(100) : idCliente,
                        NomeProduto = produto.Nome.Nome,
                        Quantidade = produto.ProdutoItens.Select(x => x.Quantidade).Sum(),
                        ValorProduto = produto.ProdutoItens.Select(x => x.Quantidade).Sum(),
                        CategoriaProduto = ECategoriaExtensions.ToDescriptionString((ECategoria)produto.CategoriaId),
                        ProdutosItens = new List<ProdutoItens> { new ProdutoItens { NomeProdutoItem = produto.Nome.Nome, Quantidade = produto.ProdutoItens.Select(x => x.Quantidade).Sum(), ValorItem = produto.ProdutoItens.Select(x => x.Quantidade).Sum() } }
                    };

                    _rabbitMqPub.Publicar(produtoSelecionadoDto, "Produto", "Produto_Selecionado");
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
