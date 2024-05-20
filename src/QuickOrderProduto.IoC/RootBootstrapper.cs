using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Application.UseCases.Produto.Interfaces;
using QuickOrderProduto.Core.Application.UseCases;
using QuickOrderProduto.Core.Application.UseCases.Produto;
using QuickOrderProduto.Domain;
using QuickOrderProduto.Infra.MQ;
using QuickOrderProduto.PostgresDB.Repositories;

namespace QuickOrderProduto.Core.IoC
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddSingleton(typeof(IRabbitMqPub<>), typeof(RabbitMqPub<>));

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);


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