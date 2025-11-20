# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project file and restore dependencies
#COPY *.csproj . # if Dockerfile is in the same directory as .csproj
COPY asp-dot-net-core-web-api-minimal-apis/*.csproj ./asp-dot-net-core-web-api-minimal-apis/

# Restore NuGet packages based on .csproj file
# RUN dotnet restore
RUN dotnet restore ./asp-dot-net-core-web-api-minimal-apis/asp-dot-net-core-web-api-minimal-apis.csproj

# Copy the rest of the code
COPY asp-dot-net-core-web-api-minimal-apis/. ./asp-dot-net-core-web-api-minimal-apis/

# Build and publish the app in Release mode to the /app/out folder
WORKDIR /app/asp-dot-net-core-web-api-minimal-apis
RUN dotnet publish -c Release -o out

# Stage 2: Runtime stage using ASP.NET Core Runtime 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Set the working directory for the runtime container
WORKDIR /app

# Copy the published output from the SDK stage
COPY --from=build /app/asp-dot-net-core-web-api-minimal-apis/out .

# Expose port inside the container (mapped to host using `docker run -p`)
EXPOSE 7076

# Run the app
ENTRYPOINT ["dotnet", "asp-dot-net-core-web-api-minimal-apis.dll"]
