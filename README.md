# ContactBook
A Code project to display coding skills using Anguarjs, .NET Core, EF Core, and MSSQL.

## Database Preparation
In the SQLScripts Folder for the solution is the SQL script to create all of the tables, 
and the seeding for the lookup tables and first User.

### Steps:
- Create a new Database named ContactBook
- Run the SQL script
- In the ContactBookAPI project
	- Change the connection string in the appsettings.json file
	- If you change anything in the Database:
      - Change the connection string in UpdateModelFromDatabase.ps1
      - Open the Package Manager Console and run UpdateModelFromDatabase.ps1

## Test URLs
Postman collection of test links: https://documenter.getpostman.com/view/505975/contactbook/77iaMsR
