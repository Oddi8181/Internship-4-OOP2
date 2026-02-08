# 👥 Internship-4-OOP2 – Users & Companies Management API

## 🔹 Short Description
ASP.NET Core Web API for managing users and companies, built using Clean Architecture with PostgreSQL, Entity Framework Core, and Dapper.

---

## 🔹 Project Overview
**Internship-4-OOP2** is a backend Web API application designed for managing users and companies.  
The project demonstrates modern backend development practices including **Clean Architecture**, **data validation**, **API integration**, and **caching mechanisms**.

It was developed as part of an internship to showcase backend skills in **ASP.NET Core**, **database access optimization**, and **API design**.

---

## 🏗 Clean Architecture
The solution is structured according to Clean Architecture principles:

- **Domain**  
  Core entities, value objects, and validation rules.

- **Application**  
  Business logic, services, and Data Transfer Objects (DTOs).

- **Infrastructure**  
  Data access layer using:
  - Entity Framework Core
  - Dapper  
  Implemented through the repository pattern and base database contexts.

- **API**  
  ASP.NET Core Web API layer exposing endpoints via controllers.  
  Integrated with **Swagger** for API documentation and testing.

---

## 🗄 Database & Persistence
- PostgreSQL
- Entity Framework Core
- Dapper for optimized data access
- Repository pattern
- Code-first migrations

---

## ✨ Functionalities

### 👤 Users
- Create, read, update, and delete users (CRUD)
- Email and username validation
- GUID-based password generation

### 🏢 Companies
- Create, read, update, and delete companies (CRUD)
- URL and domain validation rules

### 🔄 External API Integration
- Automated import of users from an external API
- Caching mechanism that prevents multiple imports within the same day

---

## 🧰 Tech Stack
- C# / .NET
- ASP.NET Core Web API
- Entity Framework Core
- Dapper
- PostgreSQL
- Clean Architecture
- Swagger / OpenAPI
- Git

---

## ▶️ Running the Application

1. Set up a PostgreSQL database
2. Configure the connection string in `appsettings.json`
3. Run database migrations:
   ```bash
   dotnet ef database update
