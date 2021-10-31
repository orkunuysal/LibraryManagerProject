#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /LibaryManagerProject

COPY ["src/Services/ReservationManager/ReservationManager.API/ReservationManager.API.csproj", "ReservationManager/ReservationManager.API/"]
COPY ["src/Services/ReservationManager/ReservationManager.Application/ReservationManager.Application.csproj", "ReservationManager/ReservationManager.Application/"]
COPY ["src/Services/ReservationManager/ReservationManager.Domain/ReservationManager.Domain.csproj", "ReservationManager/ReservationManager.Domain/"]
COPY ["src/Services/ReservationManager/ReservationManager.Infrastructure/ReservationManager.Infrastructure.csproj", "ReservationManager/ReservationManager.Infrastructure/"]

RUN dotnet restore "ReservationManager/ReservationManager.API/ReservationManager.API.csproj"

COPY . .
WORKDIR "/LibaryManagerProject/src/Services/ReservationManager/ReservationManager.API"
RUN dotnet build "ReservationManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReservationManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservationManager.API.dll"]