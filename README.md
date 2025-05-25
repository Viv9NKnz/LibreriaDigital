# 📚 Librería Digital - ASP.NET Core API

Una aplicación web API creada con ASP.NET Core que permite a los usuarios gestionar su colección de libros digitales, calificarlos y reseñarlos.

## 🚀 Características
- Registro, edición y eliminación de usuarios
- Gestión de libros (crear, listar, editar, eliminar)
- Calificación y reseñas de libros
- Persistencia en SQL Server vía Docker

## 🔧 Tecnologías
- ASP.NET Core 7
- Entity Framework Core
- SQL Server en Docker


## 📦 Scripts Clave
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## 📂 Estructura
```
LibreriaDigital/
├── Controllers/
├── Models/
├── Data/
├── Repositories/
├── Migrations/
├── Program.cs
├── appsettings.json

```

## ✅ Endpoints
- `POST /api/users`
- `GET /api/users`
- `POST /api/books`
- `GET /api/books`



---
Creado por justin alvarez laverde aprendiz del código