# FAATPRO ERP 
# FAATPRO ERP

FAATPRO ERP is a modern enterprise accounting and business management system designed to simplify financial operations, accounting workflows, and business processes.

The project is built using a scalable architecture with a .NET backend and React frontend.

---

## 🚀 Project Overview

FAATPRO ERP provides complete accounting and ERP functionality including:

- Company Management
- User & Role Management
- Accounting Modules
- Chart of Accounts
- Journal Entry Management
- Financial Reports
- Dashboard Analytics
- Customer & Vendor Management

---

# 🏗️ Technology Stack

## Backend

- .NET 10 Web API
- Entity Framework Core
- PostgreSQL Database
- JWT Authentication
- Role Based Access Control (RBAC)
- Swagger API Documentation
- Serilog Logging

Architecture:


FAATPRO.API
|
FAATPRO.Application
|
FAATPRO.Domain
|
FAATPRO.Infrastructure


---

## Frontend

- React + Vite
- Material UI
- React Router
- Redux Toolkit
- Axios
- Recharts

Frontend Structure:


frontend
|
├── src
│ ├── api
│ ├── components
│ ├── pages
│ ├── redux
│ ├── routes
│ └── styles


---

# 📂 Repository Structure


FAATPRO-Accounting

│
├── backend
│
│ ├── FAATPRO.API
│ ├── FAATPRO.Application
│ ├── FAATPRO.Domain
│ ├── FAATPRO.Infrastructure
│
│
├── frontend
│
│ ├── src
│ ├── public
│ ├── package.json
│
└── README.md


---

# ✨ Features

## Authentication & Security

✅ JWT Login System  
✅ Refresh Token  
✅ Role Based Access Control  
✅ User Management  
✅ Permission Management  


## Accounting Module

✅ Chart of Accounts  
✅ Journal Entry  
✅ Debit/Credit Management  
✅ Ledger Processing  
✅ Financial Transactions  


## Dashboard

✅ KPI Cards  
✅ Revenue Analytics  
✅ Expense Analytics  
✅ Cash Flow Charts  
✅ Transaction Summary  


## Master Management

- Company
- Branch
- Currency
- Customer
- Vendor
- Financial Year


---

# ⚙️ Installation & Setup

## Backend Setup

Go to backend folder:


cd backend


Restore packages:


dotnet restore


Update database:


dotnet ef database update


Run API:


dotnet run --project FAATPRO.API


Backend will start:


http://localhost:5184


Swagger:


http://localhost:5184/swagger


---

# Frontend Setup

Go to frontend:


cd frontend


Install dependencies:


npm install


Run application:


npm run dev


Frontend:


http://localhost:5173


---

# 🔐 Default Login


Email:
admin@faatpro.com

Password:


---

# 📌 Current Development Status

## Completed

✔ Project Architecture Setup  
✔ Authentication Module  
✔ JWT Security  
✔ Dashboard UI  
✔ Chart of Accounts  
✔ Journal Entry Module  
✔ Frontend Routing  
✔ API Integration  


## In Progress

- Customer Module
- Vendor Module
- Ledger Reports
- Financial Reports
- Invoice Management


---

# 🛣️ Future Roadmap

### Phase 1
Project Setup & Architecture

### Phase 2
Identity & Security

### Phase 3
Company Setup

### Phase 4
Accounting Core

### Phase 5
Reports & Analytics

### Phase 6
Inventory Management

### Phase 7
Payroll & HR Module


---

# 👨‍💻 Developer

FAATPRO ERP Development Team

---