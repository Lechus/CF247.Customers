FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["src/CF247.CustomersWebApi/CF247.CustomersWebApi.csproj", "src/CF247.CustomersWebApi/"]
RUN dotnet restore "src/CF247.CustomersWebApi/CF247.CustomersWebApi.csproj"
COPY . .
WORKDIR "/src/src/CF247.CustomersWebApi"
RUN dotnet build "CF247.CustomersWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CF247.CustomersWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CF247.CustomersWebApi.dll"]