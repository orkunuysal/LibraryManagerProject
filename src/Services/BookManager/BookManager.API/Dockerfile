#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /LibaryManagerProject

COPY ["src/Services/BookManager/BookManager.API/BookManager.API.csproj", "."]
RUN dotnet restore "BookManager.API.csproj"
COPY . .
WORKDIR "/LibaryManagerProject/src/Services/BookManager/BookManager.API"
RUN dotnet build "BookManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookManager.API.dll"]