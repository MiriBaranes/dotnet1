### **Bezeq Project**
The Bezeq project is a Full-Stack application that combines **.NET Core** for the backend and **React.js** for the frontend. This application was built using **.NET 8.0** and provides a shopping platform with authentication and authorization features.

---

### **Key Features**
1. **User Authentication and Registration**:
   - Users can **register** (new users) or **log in** (existing users).
   - Utilizes **IdentityUser** for user management.
   - After successful login, a **JWT Token** is generated and sent to the client.
   - The token is stored in the client's **cookies** for authenticated API calls.

2. **Shopping Functionality**:
   - Users can browse products categorized by **categories**.
   - Users can search for products across categories or within specific categories.
   - A **cart system** enables users to add, remove, and manage items in their cart.
   - Total quantities and amounts are calculated dynamically.

3. **Order Management**:
   - Authenticated users can place orders for items in their cart.
   - The backend processes the order and saves the order details in the database.
   - Users can view their past orders through the **Order History** page.

4. **Protected Routes**:
   - Certain routes are accessible only to authenticated users (e.g., order placement, order history).
   - If a user is not authenticated, they are redirected to the login page.

5. **Database**:
   - The backend uses **MySQL** as the database server.
   - However, the database can be easily switched to another provider by updating the configuration in the `appsettings.json` file and the **Program.cs** file in the backend project.

---

### **Backend Features**
1. **Frameworks and Libraries**:
   - **.NET 8.0** for backend development.
   - **AutoMapper** for mapping DTOs to entities.
   - **EF Core** for database management.
   - **JWT Authentication** for secure API calls.

2. **Packages Used**:
   - `"AutoMapper"` (Version 12.0.1)
   - `"AutoMapper.Extensions.Microsoft.DependencyInjection"` (Version 12.0.1)
   - `"Microsoft.AspNetCore.Authentication.JwtBearer"` (Version 8.0.2)
   - `"Microsoft.AspNetCore.Identity.EntityFrameworkCore"` (Version 8.0.2)
   - `"Microsoft.EntityFrameworkCore"` (Version 8.0.2)
   - `"Microsoft.EntityFrameworkCore.Design"` (Version 8.0.0)
   - `"Microsoft.AspNetCore.OpenApi"` (Version 8.0.11)

3. **How It Works**:
   - The backend uses **EF Core** to manage the database and handle relationships.
   - **IdentityUser** provides built-in user management and authentication features.
   - **JWT Tokens** are used for user authentication and authorization.
   - Protected API routes verify the **JWT token** before granting access.

4. **API Endpoints**:
   - `POST /api/Auth/register`: Registers a new user.
   - `POST /api/Auth/login`: Authenticates an existing user and returns a JWT token.
   - `GET /api/Categories/includ`: Fetches all categories and their products.
   - `POST /api/Orders`: Places a new order for authenticated users.
   - `GET /api/Orders`: Retrieves the order history for authenticated users.

---

### **Frontend Features**
1. **Frameworks and Libraries**:
   - **React.js** for building the user interface.
   - **Material-UI (MUI)** for styling components.
   - **Redux Toolkit** for state management.

2. **Pages and Components**:
   - **Login** and **Register** components for user authentication.
   - **ShoppingList**: Displays all products, categorized and searchable.
   - **CartSummary**: Summarizes selected products and provides an order placement option.
   - **UserOrders**: Displays order history for authenticated users.
   - **Navbar**: Provides navigation with a shopping cart badge to show item count.

3. **Dynamic Features**:
   - Responsive design for seamless usage across devices.
   - Search functionality for filtering products.
   - Dropdown menus for category selection.
   - Buttons for adding/removing products in the cart.

---

### **Database Configuration**
The default database used in this project is **MySQL**. If you wish to use another database (e.g., SQL Server or SQLite):
1. Update the `appsettings.json` file to include the connection string for your database.
2. Modify the database provider in the `Program.cs` file, such as switching from `UseMySql` to `UseSqlServer` or another EF Core-supported provider.

Example of `appsettings.json` configuration for MySQL:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=dotnetapp;User=root;Password=1234;"
  }
}
```

---

### **Running the Project**
1. **Backend**:
   - Run `dotnet restore` to install dependencies.
   - Update the database using `dotnet ef database update`.
   - Start the server with `dotnet run`.

2. **Frontend**:
   - git: https://github.com/MiriBaranes/bezeq-frontend.git 
   - Run `npm install` to install dependencies.
   - Start the application with `npm start`.

---
