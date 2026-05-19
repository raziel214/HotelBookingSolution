SOLUTION       := HotelBookingSolution.sln
API_PROJECT    := src/HotelBooking.Api/HotelBooking.Api.csproj
INFRA_PROJECT  := src/HotelBooking.Infrastructure/HotelBooking.Infrastructure.csproj

.PHONY: restore build test run clean docker-up docker-down docker-build migrations-add migrations-apply

restore:
	dotnet restore $(SOLUTION)

build:
	dotnet build $(SOLUTION) --configuration Release

test:
	dotnet test $(SOLUTION) --configuration Release

run:
	dotnet run --project $(API_PROJECT)

clean:
	dotnet clean $(SOLUTION)

docker-build:
	docker compose build

docker-up:
	docker compose up -d --build

docker-down:
	docker compose down

migrations-add:
	dotnet ef migrations add $(NAME) --project $(INFRA_PROJECT) --startup-project $(API_PROJECT)

migrations-apply:
	dotnet ef database update --project $(INFRA_PROJECT) --startup-project $(API_PROJECT)
