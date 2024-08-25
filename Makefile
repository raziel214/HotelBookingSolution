# Variables
PROJECT_NAME := HotelBookingSolution  # Nombre de la solución de Visual Studio
DOCKER_IMAGE := hotelbookingapi
DOCKER_TAG := latest
DOCKERFILE_PATH := ./Dockerfile
DOCKER_COMPOSE_FILE := ./docker-compose.yml

# Compila el proyecto WebApi
build:
	dotnet build WebApi.csproj 

# Publica el proyecto (ajustado para UseAppHost=false)
# Construye la imagen Docker utilizando Docker Compose para solo el servicio webapi
docker-build:
	docker-compose -f $(DOCKER_COMPOSE_FILE) build webapi

# Ejecuta Docker Compose para levantar solo el servicio webapi
docker-up:
	docker-compose -f $(DOCKER_COMPOSE_FILE) up -d webapi

# Detiene y elimina el contenedor del servicio webapi
docker-down:
	docker-compose -f $(DOCKER_COMPOSE_FILE) down

# Limpia la carpeta de publicación
clean:
	rm -rf ./publish

# Hace todo el ciclo completo enfocándose en el servicio webapi
all: build publish docker-build docker-up

.PHONY: build publish docker-build docker-up docker-down clean all
