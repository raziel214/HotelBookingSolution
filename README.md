# HotelBookingSolution

Este proyecto implementa una solución para la gestión de reservas de hoteles, utilizando una arquitectura orientada al dominio (DDD) con .NET Core.

## Índice

1. [Descripción General](#descripción-general)
2. [Arquitectura](#arquitectura)
3. [Diagrama de Contexto](#diagrama-de-contexto)
4. [Diagrama de Contenedores](#diagrama-de-contenedores)
5. [Diagrama de Componentes](#diagrama-de-componentes)
6. [Configuración](#configuración)
7. [Uso de Git Flow](#uso-de-git-flow)
8. [Contribuciones](#contribuciones)
9. [Licencia](#licencia)

## Descripción General

El proyecto **HotelBookingSolution** tiene como objetivo proporcionar una plataforma para la administración de reservas de hoteles. Está diseñado siguiendo los principios de Domain-Driven Design (DDD) y utiliza .NET Core para la implementación de servicios.

## Arquitectura

La solución sigue una arquitectura orientada al dominio con las siguientes capas:
- **Domain**: Contiene la lógica de negocio y las entidades del dominio.
- **Application**: Contiene la lógica de la aplicación y los casos de uso.
- **Infrastructure**: Maneja la persistencia de datos y las interacciones con servicios externos.
- **API**: Expone los endpoints para interactuar con la aplicación.

## Diagrama de Contexto

Este diagrama muestra la interacción de los usuarios con el sistema y los sistemas externos:

![Diagrama de Contexto](img/SamarttalentApi-Contexto.png)

## Diagrama de Contenedores

Este diagrama muestra los diferentes contenedores (microservicios, bases de datos, etc.) que componen la aplicación:

![Diagrama de Contenedores](img/SamarttalentApi-Contedores.png)

## Diagrama de Componentes

Este diagrama detalla los componentes dentro de cada contenedor:

![Diagrama de Componentes](img/SamarttalentApi-Componentes.png)

## Configuración

### Requisitos

- .NET Core 8
- Docker
- Git
- SQL Server (u otro motor de base de datos compatible)

### Instrucciones de Configuración

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/HotelBookingSolution.git
2. Debe tener instalado Docker en el equipo si no lo puedes descargar de la siguiente url:
   ```bash
   https://www.docker.com/
3. Debe  tener instalado Sqlserver en el equipo si no lo puedes descargar de la siguiente url:
   ```bash
   https://www.microsoft.com/es-co/sql-server/sql-server-downloads

4. Debe  tener instalado el ide visual studio o visual Studio code en el equipo si no lo puedes descargar de la siguiente url:
   ```bash
   https://visualstudio.microsoft.com/es/downloads/
