FROM mcr.microsoft.com/dotnet/core/sdk:3.1.403 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY global.json .
COPY SQL/WebApplication.EFCore/. ./SQL/WebApplication.EFCore/
COPY SQL/Database.EFCore/. ./SQL/Database.EFCore/
COPY Testing/. ./Testing/
RUN dotnet restore

RUN dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;" Npgsql.EntityFrameworkCore.PostgreSQL --project SQL/Database.EFCore
RUN dotnet ef migrations add Initial --project SQL/Database.EFCore
RUN dotnet ef database update --project SQL/Database.EFCore

# copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
WORKDIR /app/SQL/WebApplication.EFCore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/SQL/WebApplication.EFCore/out ./
ENTRYPOINT ["dotnet", "WebApplication.EFCore.dll"]
