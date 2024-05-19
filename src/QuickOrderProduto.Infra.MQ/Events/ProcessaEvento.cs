using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace QuickOrderProduto.Infra.MQ.Events
{
    public class ProcessaEvento : IProcessaEvento
    {
        //private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessaEvento(IServiceScopeFactory scopeFactory)
        {
            //_mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void Processa(string mensagem)
        {

            using var scope = _scopeFactory.CreateScope();

            //var itemRepository = scope.ServiceProvider.GetRequiredService<IPedidoGateway>();

            //var restauranteRead = JsonSerializer.Deserialize<ProdutoSelecionadoDto>(mensagem);

            //var restaurante = _mapper.Map<Pedido>(restauranteReadDto);

            //if (!itemRepository.ExisteRestauranteExterno(restaurante.Id))
            //{
            //    itemRepository.CreateRestaurante(restaurante);
            //    itemRepository.SaveChanges();
            //}
        }
    }
}
