﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace QuickOrderProduto.Core.Application.Events
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void Processa(string mensagem)
        {

            //using var scope = _scopeFactory.CreateScope();

            //var itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();

            //var restauranteReadDto = JsonSerializer.Deserialize<RestauranteReadDto>(mensagem);

            //var restaurante = _mapper.Map<Restaurante>(restauranteReadDto);

            //if (!itemRepository.ExisteRestauranteExterno(restaurante.Id))
            //{
            //    itemRepository.CreateRestaurante(restaurante);
            //    itemRepository.SaveChanges();
            //}
        }
    }
}