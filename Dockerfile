FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Core.API/Core.API.csproj", "Core.API/"]
COPY ["KMaSA.Models/KMaSA.Models.csproj", "KMaSA.Models/"]
COPY ["KMaSA.Infrastructure/KMaSA.Infrastructure.csproj", "KMaSA.Infrastructure/"]
COPY ["KMaSA.BusinessLogic/KMaSA.BusinessLogic.csproj", "KMaSA.BusinessLogic/"]
COPY ["DAInterfaces/DAInterfaces.csproj", "DAInterfaces/"]
COPY ["BLInterfaces/BLInterfaces.csproj", "BLInterfaces/"]
RUN dotnet restore "Core.API/Core.API.csproj"
COPY . .
WORKDIR "/src/Core.API"
RUN dotnet build "Core.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Core.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Core.API.dll", "--server.urls", "http://0.0.0.0:5000"]