# Insurance Management System Setup Guide

## Project Description

The Insurance Management System is a comprehensive platform that automates the traditional insurance workflow, including policy issuance, claims management, agent assignment, and customer engagement. Built using C# and ASP.NET Core, it ensures secure interactions for administrators, agents, and customers, streamlining operations and enhancing user satisfaction. The system offers real-time analytics and an intuitive interface for an efficient and modern insurance management experience.

## Setup Instructions

### Prerequisites

Ensure you have the following software installed:

- **Visual Studio** (with .NET Core development workload)
- **SQL Server** for database management
- **Git** for version control
- **Node.js** (if frontend dependencies are managed using npm)

### Steps to Run the Project Locally

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/rehabkhaleel/SoftwareContruction-SemesterProject/tree/main
   ```

2. **Navigate to the Project Directory:**

   ```bash
   cd Insurance-management
   ```

3. **Open the Project in Visual Studio:**

   - Launch Visual Studio and select `Open a project or solution`.
   - Navigate to the project directory and open the `.sln` file.

4. **Configure the Database:**

   - Update the connection string in `appsettings.json` to match your SQL Server configuration.
   - Run the following commands in the Visual Studio `Package Manager Console` to apply migrations:
     ```bash
     Update-Database
     ```

5. **Restore Dependencies:**

   - Restore NuGet packages by selecting `Restore NuGet Packages` in Visual Studio.

6. **Build and Run the Application:**

   - Click on `Start` or press `F5` to build and run the application.

7. **Access the Application:**

   - Open your browser and navigate to `http://localhost:5000` or the assigned port to access the Insurance Management System.

### Notes

- For production deployment, ensure secure database connections and configure environment-specific settings.
- The application supports role-based access, with different functionalities for administrators, agents, and customers.

