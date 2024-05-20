using Microsoft.EntityFrameworkCore;
using QuickOrderProduto.Api.Configuration;
using QuickOrderProduto.Domain.Entities;
using QuickOrderProduto.Infra.MQ;
using QuickOrderProduto.PostgresDB.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings")
);

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings")
);

//Configure Postgres Database
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings")
);

var migrationsAssembly = typeof(ApplicationContext).Assembly.GetName().Name;
var migrationTable = "__ProdutoMigrationsHistory";
var databaseSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(databaseSettings.ConnectionString, b =>
    {
        b.MigrationsAssembly(migrationsAssembly);
        b.MigrationsHistoryTable(migrationTable);
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});



builder.Services.AddDependencyInjectionConfiguration();

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCorsConfiguration(myAllowSpecificOrigins);

builder.Services.AddHealthChecks();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure Postgres Database Migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.RegisterExceptionHandler();

app.MapHealthChecks("/api/health");

app.UseReDoc(c =>
{
c.DocumentTitle = "QuickOrder API Documentation";
c.SpecUrl = "/swagger/v1/swagger.json";
});

//Register Produtos Endpoints
app.RegisterProdutoEndpoints();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.Run();