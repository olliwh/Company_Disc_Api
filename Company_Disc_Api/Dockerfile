# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore
COPY *.csproj .
RUN dotnet restore

# Copy everything and build
COPY . .
RUN dotnet publish *.csproj -c Release -o /app

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Configure for Render's dynamic port
ENV ASPNETCORE_ENVIRONMENT=Production

# Create startup script
RUN echo '#!/bin/bash\necho "PORT is: $PORT"\nexport ASPNETCORE_URLS="http://0.0.0.0:$PORT"\necho "ASPNETCORE_URLS is: $ASPNETCORE_URLS"\nexec dotnet Company_Disc_Api.dll' > /app/start.sh && chmod +x /app/start.sh

ENTRYPOINT ["/app/start.sh"]