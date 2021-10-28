#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /LibaryManagerProject

COPY ["src/Services/BasketManager/BasketManager.API/BasketManager.API.csproj", "."]
RUN dotnet restore "BasketManager.API.csproj"
COPY . .
WORKDIR "/LibaryManagerProject/src/Services/BasketManager/BasketManager.API"
RUN dotnet build "BasketManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketManager.API.dll"]