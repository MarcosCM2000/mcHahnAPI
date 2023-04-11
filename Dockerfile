#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mcHahnAPI/mcHahnAPI.csproj", "mcHahnAPI/"]
COPY ["mcHahn.Application/mcHahn.Application.csproj", "mcHahn.Application/"]
COPY ["mcHahn.Domain/mcHahn.Domain.csproj", "mcHahn.Domain/"]
COPY ["mcHahn.Contracts/mcHahn.Contracts.csproj", "mcHahn.Contracts/"]
COPY ["mcHahn.Infrastructure/mcHahn.Infrastructure.csproj", "mcHahn.Infrastructure/"]
RUN dotnet restore "mcHahnAPI/mcHahnAPI.csproj"
COPY . .
WORKDIR "/src/mcHahnAPI"
RUN dotnet build "mcHahnAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mcHahnAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mcHahnAPI.dll"]