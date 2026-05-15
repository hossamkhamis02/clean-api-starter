FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CleanApi.API/CleanApi.API.csproj", "src/CleanApi.API/"]
COPY ["src/CleanApi.Application/CleanApi.Application.csproj", "src/CleanApi.Application/"]
COPY ["src/CleanApi.Domain/CleanApi.Domain.csproj", "src/CleanApi.Domain/"]
COPY ["src/CleanApi.Infrastructure/CleanApi.Infrastructure.csproj", "src/CleanApi.Infrastructure/"]
RUN dotnet restore "src/CleanApi.API/CleanApi.API.csproj"
COPY . .
WORKDIR "/src/src/CleanApi.API"
RUN dotnet build "CleanApi.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CleanApi.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanApi.API.dll"]
