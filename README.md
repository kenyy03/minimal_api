# Minimal API with Clean Architecture

A lightweight ASP.NET Core Minimal API template following Clean Architecture principles, designed for building scalable and maintainable APIs.

## Features

- ✅ **Clean Architecture Layers**: Domain, Application, Infrastructure, Api
- ✅ Minimal API Endpoints
- ✅ Entity Framework Core (SQL Server) with Mappings Configurations
- ✅ Dependency Injection & Configuration Management
- ✅ Swagger/OpenAPI Documentation
- ✅ Global Error Handling

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Postman](https://www.postman.com/) (optional)

## Project Structure
src/
├── Domain/ # Domain models, entities, interfaces
│── Application/ # Use cases, DTOs
├── Infrastructure/ # Data access, external services
├── Api/ # API project (Minimal API endpoints)