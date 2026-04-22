<div align="center">

```
         P R O D U C T  M A N A G E M E N T   S Y S T E M   A P I
```

**ASP.NET Core Web API** · **Entity Framework Core** · **SQL Server** · **Swagger**

![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

</div>

---

## 👩‍💻 Author

| | |
|---|---|
| **Name** | Jana Melissa V. Regondola |
| **Course** | BS Information Technology |
| **Section** | 3A |
| **GitHub** | [@janameli](https://github.com/janameli) |

---

## 📋 About This Project

A **Product Management System API** built as a laboratory activity for the course. The API is built using **ASP.NET Core** and supports full **CRUD operations** (Create, Read, Update, Delete) for four models: Products, Categories, Suppliers, and Customers.

---

## 🗂️ Project Structure

```
ProductAPIDemo/
│
├── 📁 Controllers/
│   ├── ProductsController.cs
│   ├── CategoriesController.cs
│   ├── SuppliersController.cs
│   └── CustomersController.cs
│
├── 📁 Data/
│   └── ApplicationDBContext.cs
│
├── 📁 Models/
│   ├── Product.cs
│   ├── Category.cs
│   ├── Supplier.cs
│   └── Customer.cs
│
├── 📁 Migrations/
├── appsettings.json
├── Program.cs
└── ProductAPIDemo.csproj
```

---

## 🔗 Model Relationships

```
┌──────────────┐         ┌──────────────────┐
│   Category   │ 1 ───── │                  │
│──────────────│         │     Product      │
│ CategoryId   │  many   │──────────────────│
│ Name         │         │ ProductId        │
│ Description  │         │ Name             │
└──────────────┘         │ Description      │
                         │ Price            │
┌──────────────┐         │ Stock            │
│   Supplier   │ 1 ───── │ CategoryId (FK)  │
│──────────────│         │ SupplierId (FK)  │
│ SupplierId   │  many   └──────────────────┘
│ Name         │
│ Address      │         ┌──────────────────┐
│ ContactNo    │         │    Customer      │
│ Email        │         │──────────────────│
└──────────────┘         │ CustomerId       │
                         │ FirstName        │
                         │ LastName         │
                         │ Email            │
                         │ ContactNumber    │
                         │ Address          │
                         └──────────────────┘
```

> A **Product** belongs to one **Category** and one **Supplier**.
> A **Customer** is independent with no relationships.

---

## ⚙️ Requirements

Make sure you have the following installed before running the project:

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) *(recommended)* or [VS Code](https://code.visualstudio.com/)

---

## 🚀 Setup Guide

### Step 1 — Install the Required Tools

<details>
<summary><b>📦 Install .NET 10 SDK</b></summary>

1. Go to https://dotnet.microsoft.com/en-us/download
2. Download and run the **.NET 10** installer
3. Verify by opening a terminal and typing:
   ```bash
   dotnet --version
   ```
   You should see something like `10.0.x`

</details>

<details>
<summary><b>🗄️ Install SQL Server Express</b></summary>

1. Go to https://www.microsoft.com/en-us/sql-server/sql-server-downloads
2. Scroll down and click **Download** under **Express**
3. Run the installer and choose **Basic** installation
4. Note the server name shown at the end — usually `localhost\SQLEXPRESS`

</details>

<details>
<summary><b>🖥️ Install Visual Studio 2022</b></summary>

1. Go to https://visualstudio.microsoft.com/
2. Download **Visual Studio 2022 Community** (free)
3. During installation, select the workload: **ASP.NET and web development**
4. Click **Install**

</details>

---

### Step 2 — Open the Project

**Using Visual Studio 2022:**
1. Open Visual Studio
2. Click **Open a project or solution**
3. Navigate to the project folder and select `ProductAPIDemo.csproj`

**Using VS Code:**
1. Go to **File → Open Folder** and select the project folder
2. Open the terminal: **View → Terminal**

---

### Step 3 — Configure the Database Connection

1. Open `appsettings.json`
2. Update the connection string to match your SQL Server name:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS; Database=ProductDB; Trusted_Connection=True; TrustServerCertificate=True;"
}
```

> If your server name is different, replace `localhost\\SQLEXPRESS` accordingly.

---

### Step 4 — Run the Migrations

This creates the database and all tables automatically from the model files.

**Visual Studio — Package Manager Console:**
```powershell
Add-Migration InitialCreate
Update-Database
```

**VS Code / Terminal:**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> If `dotnet ef` is not found, install it first:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

---

### Step 5 — Run the Project

**Visual Studio:** Press `F5` or click the green ▶ **Run** button.

**Terminal:**
```bash
dotnet run
```

Then open your browser and go to:
```
https://localhost:{port}/swagger
```

---

## 🧪 Testing the API

### ✅ Using Swagger (Built-in)

Once the project is running, Swagger UI opens automatically. You'll see all four controllers listed.

**How to test:**
1. Click on any controller to expand it
2. Select an endpoint (e.g., `POST /api/Categories`)
3. Click **Try it out**
4. Fill in the request body and click **Execute**
5. Check the response at the bottom

**Example — Create a Category:**
```json
{
  "name": "Electronics",
  "description": "Electronic gadgets and devices"
}
```

**Example — Create a Product** *(add a Category and Supplier first)*:
```json
{
  "name": "Laptop",
  "description": "Gaming laptop",
  "price": 45000,
  "stock": 10,
  "categoryId": 1,
  "supplierId": 1
}
```

---

### 📬 Using Postman (Optional)

1. Download Postman at https://www.postman.com/downloads/
2. Click **New → HTTP Request**
3. Select the method (GET, POST, PUT, DELETE)
4. Enter the URL, e.g.: `https://localhost:5001/api/categories`
5. For POST/PUT: click **Body → raw → JSON**, then enter your data
6. Click **Send**

> **SSL Error?** Go to **Settings → General** and disable **SSL Certificate Verification**.

---

## 📡 API Endpoints

### 🛒 Products `/api/products`
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/products` | Get all products |
| `GET` | `/api/products/{id}` | Get product by ID |
| `POST` | `/api/products` | Create a new product |
| `PUT` | `/api/products/{id}` | Update a product |
| `DELETE` | `/api/products/{id}` | Delete a product |

### 🏷️ Categories `/api/categories`
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/categories` | Get all categories |
| `GET` | `/api/categories/{id}` | Get category by ID |
| `POST` | `/api/categories` | Create a new category |
| `PUT` | `/api/categories/{id}` | Update a category |
| `DELETE` | `/api/categories/{id}` | Delete a category |

### 🏭 Suppliers `/api/suppliers`
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/suppliers` | Get all suppliers |
| `GET` | `/api/suppliers/{id}` | Get supplier by ID |
| `POST` | `/api/suppliers` | Create a new supplier |
| `PUT` | `/api/suppliers/{id}` | Update a supplier |
| `DELETE` | `/api/suppliers/{id}` | Delete a supplier |

### 👥 Customers `/api/customers`
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/customers` | Get all customers |
| `GET` | `/api/customers/{id}` | Get customer by ID |
| `POST` | `/api/customers` | Create a new customer |
| `PUT` | `/api/customers/{id}` | Update a customer |
| `DELETE` | `/api/customers/{id}` | Delete a customer |

---

## 🛠️ Troubleshooting

| Problem | Solution |
|---------|----------|
| `Cannot connect to SQL Server` | Open **SQL Server Configuration Manager** and make sure the SQL Server service is running |
| `dotnet ef not found` | Run: `dotnet tool install --global dotnet-ef` |
| `SSL error in browser` | Click **Advanced → Proceed anyway** on the certificate warning page |
| `SSL error in Postman` | Go to **Settings → General** and turn off **SSL Certificate Verification** |

---

<div align="center">

Made with 💜 by **Jana Melissa V. Regondola** · BS Information Technology 3A

</div>
