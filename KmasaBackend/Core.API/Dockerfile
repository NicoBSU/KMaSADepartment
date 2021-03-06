#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Core.API/Core.API.csproj", "Core.API/"]
COPY ["BLInterfaces/BLInterfaces.csproj", "BLInterfaces/"]
COPY ["KMaSA.Models/KMaSA.Models.csproj", "KMaSA.Models/"]
COPY ["KMaSA.BusinessLogic/KMaSA.BusinessLogic.csproj", "KMaSA.BusinessLogic/"]
COPY ["KMaSA.Infrastructure/KMaSA.Infrastructure.csproj", "KMaSA.Infrastructure/"]
COPY ["DAInterfaces/DAInterfaces.csproj", "DAInterfaces/"]
RUN dotnet restore "Core.API/Core.API.csproj"
COPY . .
WORKDIR "/src/kmasabackend"
RUN dotnet build "Core.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Core.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.API.dll"]