# Use the official .NET SDK image for .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the runtime image for .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Set the entry point
ENTRYPOINT ["dotnet", "InMemoryCrudApp.dll"]
