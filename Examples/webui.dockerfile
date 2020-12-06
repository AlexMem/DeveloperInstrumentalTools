FROM mcr.microsoft.com/dotnet/core/sdk:3.1.403 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY global.json .
COPY SQL/WebApplication.EFCore/. ./SQL/WebApplication.EFCore/
COPY SQL/Database.EFCore/. ./SQL/Database.EFCore/
COPY Razor/. ./Razor/
COPY SignalR/. ./SignalR/
COPY Testing/. ./Testing/
RUN dotnet restore

# build app
WORKDIR /app/Razor/RazorWebApplication
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Razor/RazorWebApplication/out ./
ENTRYPOINT ["dotnet", "RazorWebApplication.dll"]
