FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EngiePowerPlantAPI/EngiePowerPlantAPI.csproj", "EngiePowerPlantAPI/"]
RUN dotnet restore "EngiePowerPlantAPI/EngiePowerPlantAPI.csproj"
COPY . .
WORKDIR "/src/EngiePowerPlantAPI"
RUN dotnet build "EngiePowerPlantAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EngiePowerPlantAPI.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EngiePowerPlantAPI.dll"]