# syntax=docker/dockerfile:1.7
# Multi-stage build para HotelBooking.Api
# Build context: raíz del repositorio

ARG DOTNET_VERSION=8.0

# --- Stage 1: restore + build ---
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

COPY Directory.Build.props ./
COPY src/HotelBooking.Domain/HotelBooking.Domain.csproj                 src/HotelBooking.Domain/
COPY src/HotelBooking.Application/HotelBooking.Application.csproj       src/HotelBooking.Application/
COPY src/HotelBooking.Infrastructure/HotelBooking.Infrastructure.csproj src/HotelBooking.Infrastructure/
COPY src/HotelBooking.Api/HotelBooking.Api.csproj                       src/HotelBooking.Api/

RUN dotnet restore "src/HotelBooking.Api/HotelBooking.Api.csproj"

COPY src/ src/
RUN dotnet publish "src/HotelBooking.Api/HotelBooking.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

# --- Stage 2: runtime ---
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS final
WORKDIR /app

RUN apt-get update \
    && apt-get install -y --no-install-recommends curl \
    && rm -rf /var/lib/apt/lists/* \
    && groupadd --system --gid 1000 app \
    && useradd --system --uid 1000 --gid app --home /app app \
    && mkdir -p /app/logs \
    && chown -R app:app /app

COPY --from=build --chown=app:app /app/publish .

ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_USE_POLLING_FILE_WATCHER=true

USER app
EXPOSE 8080

HEALTHCHECK --interval=30s --timeout=5s --start-period=20s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "HotelBooking.Api.dll"]
