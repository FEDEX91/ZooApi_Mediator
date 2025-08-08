
I'm working on this project to help other developers better understand Web APIs.

Environment:
1. Visual Studio 2022
2. Microsoft SQL Server

Packages Used:
1. MediatR
2. Entity Framework Core
3. AutoMapper

In the appsettings.json file, update the DefaultConnection string with your local SQL Server details.
Once you've updated the connection string, open a terminal in Visual Studio and run the following commands to create the database:

1. dotnet ef migrations add InitDb
2. dotnet ef database update
