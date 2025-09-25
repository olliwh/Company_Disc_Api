# Modified Visual Studio Dockerfile for Render.com deployment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Company_Disc_Api/Company_Disc_Api.csproj", "Company_Disc_Api/"]
RUN dotnet restore "./Company_Disc_Api/Company_Disc_Api.csproj"
COPY . .
WORKDIR "/src/Company_Disc_Api"
RUN dotnet build "./Company_Disc_Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Company_Disc_Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables for Render.com
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "Company_Disc_Api.dll"]