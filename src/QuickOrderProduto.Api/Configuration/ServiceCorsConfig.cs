﻿namespace QuickOrderProduto.Api.Configuration
{
    public static class ServiceCorsConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection service, string myAllowSpecificOrigins)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .WithOrigins("http://localhost:8090");
                                  });
            });
        }
    }
}
