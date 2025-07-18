# 🚀 Department & Employee Management API

A complete ASP.NET Core Web API project for managing **Departments** and **Employees** using **Entity Framework Core** and **DTOs**. This project provides full CRUD functionality and follows clean code architecture for maintainability and scalability.

---

## 📦 Features

- ✅ CRUD operations for Departments
- ✅ CRUD operations for Employees
- ✅ Relational mapping between Department and Employee entities
- ✅ Clean separation using DTOs
- ✅ Data persistence using Entity Framework Core
- ✅ Ready-to-test endpoints using Swagger

---

## 🛠️ Technologies Used

- ASP.NET Core Web API (.NET 6/7)
- Entity Framework Core
- SQL Server (or any relational database)
- Swagger for API testing
- LINQ and Asynchronous programming

---

## 📁 Project Structure

```
Department-API/
├── Controllers/
│   ├── DepartmentsController.cs
│   └── EmployeesController.cs
├── Models/
│   ├── Department.cs
│   └── Employee.cs
├── DTOs/
│   ├── DepartmentDTO.cs
│   └── EmployeeDTO.cs
├── Data/
│   └── AppDbContext.cs
├── Program.cs
├── Startup.cs (if .NET 6 or earlier)
└── README.md
```

---

## 🧰 How to Run the Project Locally

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/Department-API.git
   cd Department-API
   ```

2. **Add Connection String in `appsettings.json`**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SQL_SERVER;Database=OrgDb;Trusted_Connection=True;"
   }
   ```

3. **Apply Migrations and Update Database**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the Project**
   ```bash
   dotnet run
   ```

---

## 🌐 Available API Endpoints

### Department Endpoints:

- `GET /api/departments` — Get all departments
- `GET /api/departments/{id}` — Get department by ID
- `POST /api/departments` — Create a new department
- `PUT /api/departments/{id}` — Update a department
- `DELETE /api/departments/{id}` — Delete a department

### Employee Endpoints:

- `GET /api/employees` — Get all employees
- `GET /api/employees/{id}` — Get employee by ID
- `POST /api/employees` — Create a new employee
- `PUT /api/employees/{id}` — Update an employee
- `DELETE /api/employees/{id}` — Delete an employee

---

## 👤 Author

Developed by **Lesyan Buirat** — Passionate about backend APIs, creative user interfaces, and building real-world .NET solutions

---

## 📬 License

This project is open-source and free to use under the [MIT License]().
```

---

