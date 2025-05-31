# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
# Базовый слой с ASP.NET Core рантаймом
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Railway предоставляет порт в переменной PORT — мы его используем
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}

EXPOSE 8080

# Слой сборки с SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем только csproj сначала — для кэширования restore
COPY ["API_Restoran/API_Restoran.csproj", "API_Restoran/"]
RUN dotnet restore "API_Restoran/API_Restoran.csproj"

# Копируем остальной исходный код
COPY . .
WORKDIR "/src/API_Restoran"

# Собираем проект
RUN dotnet build "API_Restoran.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Публикация (сборка в финальный минимальный набор файлов)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "API_Restoran.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный слой — образ, который запускается в Railway
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Основная команда запуска
ENTRYPOINT ["dotnet", "API_Restoran.dll"]
