# CRUD de Notas

Aplicación web para la gestión de notas (crear, listar, editar y eliminar) 
desarrollada con:
- Backend: .NET 8 + Entity Framework + SQL Server
- Frontend: Angular

Incluye eliminación lógica (soft delete), manejo de fechas automático y API REST.

## Tecnologías

### Backend
- .NET 8
- Entity Framework Core
- SQL Server

### Frontend
- Angular
- TypeScript
- SweetAlert2

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio

git clone https://github.com/Dfrrer27/crud-nota-back.git
cd repo

### 2. Ejecutas en la consola administrador de paquetes "dotnet restore"

### 3. Editar el archivo appsettings.json
Ejemplo
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=NotasDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

lo modificas segun tu base de datos local y ejecutas

### 4. Ejecutas el siguiente comando "update-database"

y listo ya ejecutas el proyecto y tendrias el back funcionando!!


