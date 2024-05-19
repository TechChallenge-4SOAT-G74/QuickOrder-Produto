using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Adapters.PostgresDB.Repositories;
using QuickOrderProduto.Application.Events;
using QuickOrderProduto.Core.Application.UseCases;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Infra.MQ;

namespace QuickOrderProduto.Core.IoC
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddSingleton(typeof(IRabbitMqPub<>), typeof(RabbitMqPub<>));
            services.AddSingleton<IProcessaEvento, ProcessaEvento>();


            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseUseCase), assemblyTypes);

            //Repositories postgresDB

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IProdutoItemRepository, ProdutoItemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            //UseCases
            services.AddScoped<IProdutoAtualizarUseCase, ProdutoAtualizarUseCase>();
            services.AddScoped<IProdutoExcluirUseCase, ProdutoExcluirUseCase>();
            services.AddScoped<IProdutoCriarUseCase, ProdutoCriarUseCase>();
            services.AddScoped<IProdutoObterUseCase, ProdutoObterUseCase>();
            services.AddScoped<IProdutoSelecionarUseCase, ProdutoSelecionarUseCase>();
        }
    }
}