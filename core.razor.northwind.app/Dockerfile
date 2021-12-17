#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM bitnami/dotnet AS base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM bitnami/dotnet-sdk AS build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["core.razor.northwind.app/core.razor.northwind.app.csproj", "core.razor.northwind.app/"]
RUN dotnet restore "core.razor.northwind.app/core.razor.northwind.app.csproj"
COPY . .
WORKDIR "/src/core.razor.northwind.app"
RUN dotnet build "core.razor.northwind.app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "core.razor.northwind.app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "core.razor.northwind.app.dll"]