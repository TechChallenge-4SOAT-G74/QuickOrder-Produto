#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuickOrderProduto.Api/QuickOrderProduto.Api.csproj", "QuickOrderProduto.Api/"]
COPY ["QuickOrderProduto.PostgresDB/QuickOrderProduto.PostgresDB.csproj", "QuickOrderProduto.PostgresDB/"]
COPY ["QuickOrderProduto.Application/QuickOrderProduto.Application.csproj", "QuickOrderProduto.Application/"]
COPY ["QuickOrderProduto.Domain/QuickOrderProduto.Domain.csproj", "QuickOrderProduto.Domain/"]
COPY ["QuickOrderProduto.Infra.MQ/QuickOrderProduto.Infra.MQ.csproj", "QuickOrderProduto.Infra.MQ/"]
COPY ["QuickOrderProduto.IoC/QuickOrderProduto.IoC.csproj", "QuickOrderProduto.IoC/"]
COPY ["QuickOrderProduto.Tests/QuickOrderProduto.Tests.csproj", "QuickOrderProduto.Tests/"]
RUN dotnet restore "./QuickOrderProduto.Api/QuickOrderProduto.Api.csproj"
COPY . .
WORKDIR "/src/QuickOrderProduto.Api"
RUN dotnet build "./QuickOrderProduto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuickOrderProduto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuickOrderProduto.Api.dll"]