using System.Diagnostics.CodeAnalysis;

namespace QuickOrderProduto.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
    }

    [ExcludeFromCodeCoverage]
    public class DatabaseMongoDBSettings : DatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;

    }
}
