# Product Management System API

A multi-model ASP.NET Core Web API built with Entity Framework Core and SQL Server, implementing full CRUD operations for a Product Management System.

---

## Lab Activity

**Course:** ASP.NET Core Web API with Entity Framework Core  
**Activity:** Multi-Model Web API with CRUD Operations  
**Objective:** Enhance a basic Web API project by adding three additional models and implementing complete CRUD operations for each.

## Tech Stack

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core 9
- SQL Server (LocalDB / SQL Express)
- Swagger / OpenAPI


## Project Structure

```
ProductAPIDemo/
├── Controllers/
│   ├── ProductsController.cs
│   ├── CategoriesController.cs
│   ├── SuppliersController.cs
│   └── CustomersController.cs
├── Data/
│   └── ApplicationDBContext.cs
├── Models/
│   ├── Product.cs
│   ├── Category.cs
│   ├── Supplier.cs
│   └── Customer.cs
├── Migrations/
├── appsettings.json
└── Program.cs
```

---

## Models

| Model | Description |
|-------|-------------|
| `Product` | Core product with name, description, price, and stock |
| `Category` | Groups products by category |
| `Supplier` | Supplier information linked to products |
| `Customer` | Independent customer records |

### Relationships
- One **Category** → many **Products**
- One **Supplier** → many **Products**
- One **Product** belongs to one **Category**
- One **Product** belongs to one **Supplier**
- **Customer** is independent

---

## API Endpoints

### Products
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Get all products |
| GET | `/api/products/{id}` | Get product by ID |
| POST | `/api/products` | Create a new product |
| PUT | `/api/products/{id}` | Update a product |
| DELETE | `/api/products/{id}` | Delete a product |

### Categories
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | Get all categories |
| GET | `/api/categories/{id}` | Get category by ID |
| POST | `/api/categories` | Create a new category |
| PUT | `/api/categories/{id}` | Update a category |
| DELETE | `/api/categories/{id}` | Delete a category |

### Suppliers
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/suppliers` | Get all suppliers |
| GET | `/api/suppliers/{id}` | Get supplier by ID |
| POST | `/api/suppliers` | Create a new supplier |
| PUT | `/api/suppliers/{id}` | Update a supplier |
| DELETE | `/api/suppliers/{id}` | Delete a supplier |

### Customers
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/customers` | Get all customers |
| GET | `/api/customers/{id}` | Get customer by ID |
| POST | `/api/customers` | Create a new customer |
| PUT | `/api/customers/{id}` | Update a customer |
| DELETE | `/api/customers/{id}` | Delete a customer |

---

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server or SQL Server Express
- Visual Studio 2022 or VS Code

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/YourUsername/LastName_Section_Minimal_API.git
   cd LastName_Section_Minimal_API
   ```

2. **Configure the database connection**

   Open `appsettings.json` and update the connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS; Database=ProductDB; Trusted_Connection=True; TrustServerCertificate=True;"
   }
   ```

3. **Apply migrations**
   ```bash
   cd ProductAPIDemo
   dotnet ef database update
   ```

4. **Run the project**
   ```bash
   dotnet run
   ```

5. **Open Swagger UI**

   Navigate to `https://localhost:{port}/swagger` in your browser to test all endpoints.

---

## Author
**Jana Melissa V. Regondola**
Course: BS Information Technology
Section: 3A

GitHub Repository: [https://github.com/janameli/Regondola_BSIT3A_Minimal_API]
---

