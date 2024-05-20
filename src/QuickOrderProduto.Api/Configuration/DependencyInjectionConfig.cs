using QuickOrderProduto.Core.IoC;
using System.Diagnostics.CodeAnalysis;

namespace QuickOrderProduto.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RootBootstrapper.BootstrapperRegisterServices(services);
        }
    }
}
