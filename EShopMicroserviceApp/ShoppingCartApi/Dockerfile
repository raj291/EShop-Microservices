FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingCartApi/ShoppingCartApi.csproj", "ShoppingCartApi/"]
COPY ["ShopingCartApi.Core/ShopingCartApi.Core.csproj", "ShopingCartApi.Core/"]
COPY ["ShoppingCartApi.Infrastructure/ShoppingCartApi.Infrastructure.csproj", "ShoppingCartApi.Infrastructure/"]
RUN dotnet restore "ShoppingCartApi/ShoppingCartApi.csproj"
COPY . .
WORKDIR "/src/ShoppingCartApi"
RUN dotnet build "ShoppingCartApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShoppingCartApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCartApi.dll"]
