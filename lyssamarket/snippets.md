$ dotnet new mvc --auth Individual --use-local-db
$ dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.0  
$ dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.4
$ dotnet restore

// Corrigindo um Bug do Entity (First Delete Folder Migrations)
$ dotnet ef migrations add CreateIdentitySchema
$ dotnet tool install --global dotnet-ef

// Create Migration
$ dotnet ef migrations add CreateLyssaMarketSchema
$ dotnet ef database update
    Build started...
    Build succeeded.
    Done.
// 
