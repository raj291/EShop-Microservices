FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ProductDb="Server=host.docker.internal,1433; Database=ProductDb; User=sa; Password=AntraSEP98!; TrustServerCertificate=true"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductApi/ProductApi.csproj", "ProductApi/"]
COPY ["ProductApi.Core/ProductApi.Core.csproj", "ProductApi.Core/"]
COPY ["ProductApi.Infrastructure/ProductApi.Infrastructure.csproj", "ProductApi.Infrastructure/"]
RUN dotnet restore "ProductApi/ProductApi.csproj"
COPY . .
WORKDIR "/src/ProductApi"
RUN dotnet build "ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductApi.dll"]
