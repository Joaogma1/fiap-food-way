# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Foodway.sln ./
COPY Foodway.Api/Foodway.Api.csproj Foodway.Api/
COPY Foodway.Config/Foodway.Config.csproj Foodway.Config/
COPY Foodway.Application/Foodway.Application.csproj Foodway.Application/
COPY Foodway.Domain/Foodway.Domain.csproj Foodway.Domain/
COPY Foodway.Infrastructure/Foodway.Infrastructure.csproj Foodway.Infrastructure/
COPY Foodway.Shared/Foodway.Shared.csproj Foodway.Shared/

RUN dotnet restore

COPY . .
WORKDIR /src/Foodway.Api
RUN dotnet publish -c Release -o /app/publish

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose ports
EXPOSE 8080

# Entry point to run the application
ENTRYPOINT ["dotnet", "Foodway.Api.dll"]
