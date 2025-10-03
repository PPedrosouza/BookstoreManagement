# BookstoreManagement API

A RESTful API for bookstore management built with .NET 8 and Entity Framework Core.

## 🛠️ Tools and Technologies Used

- **.NET 8** - Main framework
- **ASP.NET Core Web API** - For creating the RESTful API
- **Entity Framework Core** - ORM for database access
- **SQL Server** - Database (via Docker)
- **Visual Studio 2022** - Development IDE
- **Docker** - For SQL Server containerization
- **Swagger/OpenAPI** - Automatic API documentation

## 📦 NuGet Packages Installed

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
```

## 🏗️ Project Structure

```
BookstoreManagement/
├── Controllers/
│   └── BookstoreController.cs
├── Communication/
│   ├── Requests/
│   │   ├── RequestRegisterBookJson.cs
│   │   └── UpdateBookJson.cs
│   └── Responses/
│       └── ResponseRegisterBookJson.cs
├── Data/
│   └── BookstoreDbContext.cs
├── Migrations/
│   └── 20251003014434_InitialCreate.cs
├── Book.cs
├── Program.cs
└── appsettings.json
```

## 🚀 How to Run

### 1. Prerequisites
- Visual Studio 2022
- Docker Desktop
- .NET 8 SDK

### 2. Database Setup

**Run SQL Server via Docker:**
```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

### 3. Run Migrations

In Visual Studio Package Manager Console:
```
Update-Database
```

### 4. Run the Application

Press `F5` in Visual Studio or execute:
```sh
dotnet run
```

## 📋 API Endpoints

### Base URL: `https://localhost:7xxx/api/book`

| Method | Endpoint | Description | Status Code |
|--------|----------|-------------|-------------|
| `GET` | `/` | List all books | 200 OK |
| `GET` | `/{id}` | Get book by ID | 200 OK / 404 Not Found |
| `POST` | `/` | Create a new book | 201 Created |
| `PUT` | `/{id}` | Update a book | 204 No Content / 404 Not Found |
| `DELETE` | `/{id}` | Delete a book | 204 No Content / 404 Not Found |

## 📊 Data Model

### Book (Main Entity)
```json
{
  "id": 1,
  "title": "Book Title",
  "author": "Author Name",
  "gender": "Book Genre",
  "price": 29.90,
  "stockQuantity": 100
}
```

## 🔧 Usage Examples

### Create a book (POST)
```json
POST /api/book
Content-Type: application/json

{
  "title": "The Hobbit",
  "author": "J.R.R. Tolkien",
  "gender": "Fantasy",
  "price": 45.90,
  "stockQuantity": 50
}
```

### Update a book (PUT)
```json
PUT /api/book/1
Content-Type: application/json

{
  "title": "The Hobbit - Special Edition",
  "author": "J.R.R. Tolkien",
  "gender": "Fantasy",
  "price": 55.90,
  "stockQuantity": 30
}
```

## Requirements
- It must be possible to create a book;
- It must be possible to view all books that have been created;
- It must be possible to edit information about a book;
- It must be possible to delete a book.
  
## 🎯 Implemented Features

- ✅ **Complete CRUD** - Create, read, update, and delete books
- ✅ **Data Persistence** - Data saved in SQL Server
- ✅ **Validations** - Existence checks for operations
- ✅ **HTTP Status Codes** - Appropriate responses for each operation
- ✅ **Asynchronous Operations** - Better API performance

## 🏆 Final Result

The API is fully functional and allows:
- Managing a book catalog
- Complete CRUD operations via HTTP
- Data persistence in SQL Server
- Appropriate HTTP response codes
- Implemented business validations

---

**Built with .NET 8 + Entity Framework Core** 🚀
