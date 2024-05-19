using Microsoft.EntityFrameworkCore;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrderProduto.Core.Domain.Entities;

namespace QuickOrderProduto.Api.Configuration
{
    public static class DataBaseConfig
    {
        public static void PostGresConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<DatabaseSettings>(
                configuration.GetSection("DatabaseSettings")
                );

            var migrationsAssembly = typeof(ApplicationContext).Assembly.GetName().Name;
            var migrationTable = "__ProdutoMigrationsHistory";

            DatabaseSettings databaseSettings = new DatabaseSettings();
            string postgres = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_POSTGRES");

            if (!string.IsNullOrEmpty(postgres))
                databaseSettings.ConnectionString = postgres;
            else
                databaseSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

            service.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(databaseSettings.ConnectionString, b =>
                {
                    b.MigrationsAssembly(migrationsAssembly);
                    b.MigrationsHistoryTable(migrationTable);
                });

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });
        }

        public static void MigratePostGresConfiguration(this IServiceProvider service)
        {
            using (var scope = service.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                db.Database.Migrate();
            }
        }
    }
}
