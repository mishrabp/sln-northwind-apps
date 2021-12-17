#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM bitnami/dotnet AS base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
LABEL developer=bibhup_mishra@yahoo.com
MAINTAINER Devops Engineer(bibhup_mishra@yahoo.com)
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM bitnami/dotnet-sdk AS build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["core.northwind.api/core.northwind.api.csproj", "core.northwind.api/"]
RUN dotnet restore "core.northwind.api/core.northwind.api.csproj"
COPY . .
WORKDIR "/src/core.northwind.api"
RUN dotnet build "core.northwind.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "core.northwind.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "core.northwind.api.dll"]