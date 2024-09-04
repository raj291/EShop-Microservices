FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV CustomerDb="Server=host.docker.internal,1433; Database=CustomerDb; User=sa; Password=AntraSEP98!; TrustServerCertificate=true"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerApi/CustomerApi.csproj", "CustomerApi/"]
COPY ["CustomerApi.Core/CustomerApi.Core.csproj", "CustomerApi.Core/"]
COPY ["CustomerApi.Infrastructure/CustomerApi.Infrastructure.csproj", "CustomerApi.Infrastructure/"]
RUN dotnet restore "CustomerApi/CustomerApi.csproj"
COPY . .
WORKDIR "/src/CustomerApi"
RUN dotnet build "CustomerApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerApi.dll"]
