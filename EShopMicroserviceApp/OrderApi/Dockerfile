FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV OrderDb="Server=host.docker.internal,1433; Database=OrderDb; User=sa; Password=AntraSEP98!; TrustServerCertificate=true"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderApi/OrderApi.csproj", "OrderApi/"]
COPY ["OrderApi.Core/OrderApi.Core.csproj", "OrderApi.Core/"]
COPY ["OrderApi.Infrastructure/OrderApi.Infrastructure.csproj", "OrderApi.Infrastructure/"]
RUN dotnet restore "OrderApi/OrderApi.csproj"
COPY . .
WORKDIR "/src/OrderApi"
RUN dotnet build "OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]
