using QuickOrderProduto.Api.Configuration;
using QuickOrderProduto.Infra.MQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings")
);

//Configure Postgres Database
builder.Services.PostGresConfiguration(builder.Configuration);

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
//app.MigratePostGresConfiguration();
app.Services.MigratePostGresConfiguration();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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