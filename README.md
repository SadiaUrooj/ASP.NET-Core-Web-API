# NZWalks Project

## 📌 Project Overview
**NZWalks** is a .NET web application designed for managing walking tracks and trails in New Zealand.  
The project follows a modern **Web API architecture** with a separate frontend **MVC UI component**.

---

## 🏗️ Project Structure
- **NZWalks.API** → Backend REST API service  
- **NZWalksUI** → Frontend MVC application  

---

## ⚙️ Technologies and Libraries Used
1. **ASP.NET Core** – Web framework for API and UI  
2. **Entity Framework Core** – ORM for database operations  
3. **SQL Server** – Database for storing application data  
4. **JWT Authentication** – Secure API access  
5. **ASP.NET Identity Framework** – Authentication & authorization  
6. **AutoMapper** – Object-to-object mapping  
7. **Swagger / OpenAPI** – API documentation  
8. **Serilog** – Structured logging  
9. **MVC Pattern** – For the UI architecture  

---

## 🔑 Key Components

### Backend (NZWalks.API)
- **Controllers** → Handle HTTP requests (Regions, Walks, Auth, Images)  
- **Repositories** → Data access layer with interface-based design  
- **Models** → Domain models and DTOs  
- **Middleware** → Custom exception handling  
- **Authentication** → JWT with ASP.NET Identity  
- **File Storage** → Local image repository  

### Frontend (NZWalksUI)
- **MVC Controllers** → Handle user interactions  
- **Views** → Razor Views for UI rendering  
- **Models** → ViewModels for data presentation
    
<img width="1075" height="953" alt="image" src="https://github.com/user-attachments/assets/e48d6a8d-dd16-443d-804e-9b23f040e1a5" />

---

## 🔄 Project Flow

<img width="961" height="481" alt="Project flow diagram" src="https://github.com/user-attachments/assets/39afbff9-525d-4370-80b3-e6a5a1b0ae6c" />


---


## 🔄 Data Flow
1. Client sends request to API  
2. Controller receives request  
3. Controller uses repository to access data  
4. Repository interacts with **DbContext**  
5. DbContext communicates with **SQL Server**  
6. Data flows back through the same path to client
   
<img width="942" height="590" alt="Dataflow diagram" src="https://github.com/user-attachments/assets/dfc7926a-1113-4852-96f7-0bf3d95cbb06" />

---

### 📋 Prerequisites
- .NET SDK **6.0 or later**  
- SQL Server instance  

### ⚡ Important Commands
```bash
# ✅ Add a migration to the default DbContext
Add-Migration "MigrationName"

# ✅ Add a migration to a specific DbContext
Add-Migration "MigrationName" -Context "YourContextName"

# ✅ Apply pending migrations to the default database
Update-Database

# ✅ Apply migrations to a specific DbContext's database
Update-Database -Context "YourContextName"
