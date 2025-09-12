
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

<img width="1517" height="699" alt="image" src="https://github.com/user-attachments/assets/72bc47d5-cbdd-4d0a-89f3-a5c47777be1a" />

This project includes unit test:

We used nUnit and Moq to test all the controllers, feel free to review our code.

<img width="923" height="400" alt="image" src="https://github.com/user-attachments/assets/db9c2de2-21f2-4214-8a07-5944bd2cc732" />


