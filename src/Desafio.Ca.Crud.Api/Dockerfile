#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Desafio.Ca.Crud.Api/Desafio.Ca.Crud.Api.csproj", "Desafio.Ca.Crud.Api/"]
COPY ["Desafio.Ca.Crud.Application/Desafio.Ca.Crud.Application.csproj", "Desafio.Ca.Crud.Application/"]
COPY ["Desafio.Ca.Crud.Domain/Desafio.Ca.Crud.Domain.csproj", "Desafio.Ca.Crud.Domain/"]
COPY ["Desafio.Ca.Crud.Infra.CrossCutting/Desafio.Ca.Crud.Infra.CrossCutting.csproj", "Desafio.Ca.Crud.Infra.CrossCutting/"]
COPY ["Desafio.Ca.Crud.Infra.DataBase/Desafio.Ca.Crud.Infra.DataBase.csproj", "Desafio.Ca.Crud.Infra.DataBase/"]
RUN dotnet restore "Desafio.Ca.Crud.Api/Desafio.Ca.Crud.Api.csproj"
COPY . .
WORKDIR "/src/Desafio.Ca.Crud.Api"
RUN dotnet build "Desafio.Ca.Crud.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio.Ca.Crud.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Ca.Crud.Api.dll"]