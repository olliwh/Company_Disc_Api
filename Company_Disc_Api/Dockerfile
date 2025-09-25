# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY Company_Disc_Api/Company_Disc_Api.csproj ./Company_Disc_Api/
RUN dotnet restore Company_Disc_Api/Company_Disc_Api.csproj

# Copy everything and build
COPY Company_Disc_Api/. ./Company_Disc_Api/
RUN dotnet publish Company_Disc_Api/Company_Disc_Api.csproj -c Release -o /app

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app .

# Render provides PORT env var
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 10000

ENTRYPOINT ["dotnet", "Company_Disc_Api.dll"]
