FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Company_Disc_Api.csproj", "."]
RUN dotnet restore "Company_Disc_Api.csproj"
COPY . .
RUN dotnet build "Company_Disc_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company_Disc_Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Company_Disc_Api.dll"]