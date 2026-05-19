# HotelBookingSolution

API .NET 8 para gestión de reservas de hotel con autenticación JWT, implementada con **Arquitectura Hexagonal + Vertical Slicing + CQRS**.

## Stack

- .NET 8 · ASP.NET Core (Minimal APIs)
- EF Core 8 + SQL Server 2022
- MediatR · FluentValidation · AutoMapper
- JWT Bearer + BCrypt.Net (password hashing)
- Serilog (Console + File) · Swagger / OpenAPI
- xUnit + Moq + FluentAssertions
- Docker + docker-compose
- GitHub Actions (Linux)

## Estructura

```
HotelBookingSolution/
├── src/
│   ├── HotelBooking.Domain/          ← Entidades + DomainException (sin dependencias)
│   ├── HotelBooking.Application/     ← CQRS por feature (MediatR + FluentValidation + AutoMapper)
│   ├── HotelBooking.Infrastructure/  ← EF Core, JWT, BCrypt, repos, UnitOfWork
│   └── HotelBooking.Api/             ← Minimal APIs + GlobalExceptionHandler
├── tests/
│   └── HotelBooking.Tests/           ← xUnit + Moq sobre Handlers
├── img/                              ← Diagramas C4
├── .github/workflows/ci.yml          ← Build + test + docker build
├── Dockerfile                        ← Multi-stage Linux 8.0, no-root, healthcheck /health
├── docker-compose.yml                ← API + SQL Server 2022
├── Directory.Build.props             ← TargetFramework + nullable + LangVersion
├── HotelBookingSolution.sln
└── Makefile
```

### Features (Application)

- `Authentication/` — `Login` (emite JWT)
- `Users/` — `Register`, `GetById`
- `Roles/` — `Create`, `Update`, `Delete`, `GetById`, `GetAll`
- `Hoteles/` — CRUD + `GetByCodigo`, `GetByEstado`
- `Habitaciones/` — CRUD + `GetByHotel`, `GetByTipo`, `GetByEstado`
- `TiposHabitaciones/` — CRUD
- `Reservas/` — `Create`, `Update`, `Cancelar`, `GetById`, `GetAll`
- `HotelesPreferidos/` — `Add`, `Remove`, `GetAll`, `GetByUser`

Cada feature contiene `Commands/<UseCase>/` y `Queries/<UseCase>/` con `Command/Query` (record) + `Validator` (FluentValidation) + `Handler` (sealed + primary constructor).

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (opcional, para `docker compose`)
- [EF Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`

## Configuración

Las credenciales **no** se versionan. Copia el ejemplo:

```bash
cp .env.example .env
```

Edita `.env` y define:

| Variable | Descripción |
|---|---|
| `SA_PASSWORD` | Password del usuario `sa` de SQL Server en el contenedor |
| `JWT_KEY` | Clave de firma JWT (mínimo 32 caracteres en base64) |
| `ConnectionStrings__DefaultConnection` | Override del connection string (opcional para Docker) |

Para ejecución local sin Docker, exporta también en tu shell:

```bash
export ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=HotelReservationsDB;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=true;Encrypt=False"
export Jwt__Key="$JWT_KEY"
```

## Comandos comunes

```bash
# Restaurar + compilar + tests
make restore
make build
make test

# Ejecutar API local (http://localhost:5023, Swagger en /swagger)
make run

# Levantar API + SQL Server con Docker (http://localhost:8080)
make docker-up
curl http://localhost:8080/health
make docker-down
```

## Migraciones EF Core

Tras la primera clonación o cuando cambies entidades:

```bash
# Crear migración (sustituye NAME)
make migrations-add NAME=InitialCreate

# Aplicarla a la base de datos
make migrations-apply
```

Equivalente sin Makefile:

```bash
dotnet ef migrations add InitialCreate \
  --project src/HotelBooking.Infrastructure \
  --startup-project src/HotelBooking.Api

dotnet ef database update \
  --project src/HotelBooking.Infrastructure \
  --startup-project src/HotelBooking.Api
```

> **Nota**: La migración inicial no está versionada todavía — se generó después del refactor a Hexagonal+CQRS. Genérala localmente con el comando de arriba antes del primer arranque.

## Endpoints principales

| Método | Ruta | Auth | Descripción |
|---|---|---|---|
| GET | `/health` | público | Healthcheck para Docker / monitorización |
| POST | `/api/Hotel/v1/auth/login` | público | Login → devuelve JWT |
| POST | `/api/Hotel/v1/users/register` | público | Registro de usuario |
| GET | `/api/Hotel/v1/users/{id}` | JWT | Detalle de usuario |
| CRUD | `/api/Hotel/v1/roles` | JWT | Roles |
| CRUD | `/api/Hotel/v1/hoteles` | JWT | Hoteles |
| CRUD | `/api/Hotel/v1/habitaciones` | JWT | Habitaciones |
| CRUD | `/api/Hotel/v1/tipos-habitaciones` | JWT | Tipos de habitación |
| CRUD | `/api/Hotel/v1/reservas` | JWT | Reservas (`POST {id}/cancelar` para cancelar) |
| CRUD | `/api/Hotel/v1/hoteles-preferidos` | JWT | Hoteles preferidos por usuario |

Swagger expone toda la documentación en `http://localhost:<puerto>/swagger` (solo en `Development`).

## Manejo de errores

Las excepciones se mapean a `ProblemDetails` (RFC 7807) en [GlobalExceptionHandler.cs](src/HotelBooking.Api/Middleware/GlobalExceptionHandler.cs):

| Excepción | HTTP |
|---|---|
| `FluentValidation.ValidationException` | 400 Bad Request |
| `HotelBooking.Application.Common.Exceptions.NotFoundException` | 404 Not Found |
| `HotelBooking.Domain.Common.DomainException` | 400 Bad Request |
| `UnauthorizedAccessException` | 401 Unauthorized |
| _otra_ | 500 Internal Server Error |

## CI/CD

`.github/workflows/ci.yml` ejecuta en cada PR/push a `main`/`develop`:

1. `dotnet restore` + cache de NuGet
2. `dotnet build` en Release
3. `dotnet test`
4. Build de la imagen Docker (sin push)

## Diagramas

Diagramas C4 del sistema en [img/](img/).

## Convenciones

- Idioma del repo: español. Términos técnicos en inglés OK.
- Endpoints delegan en `ISender` (MediatR). Nada de lógica en el endpoint.
- Toda I/O externa va por un puerto definido en `Application/Common/Ports/`.
- Entidades del Domain con `private setters`, fábrica `Create(...)`, método `Update(...)`. Invariantes lanzan `DomainException`.
- DTOs son `record`s.
- Configuración por `IOptions<XxxSettings>` con `const string SectionName`. Nada de credenciales hardcoded.
