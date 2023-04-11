#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mcHahnAPI/mcHahn.Domain/mcHahn.Domain.csproj", "mcHahn.Domain/"]
RUN dotnet restore "mcHahn.Domain/mcHahn.Domain.csproj"

COPY ["mcHahnAPI/mcHahn.Contracts/mcHahn.Contracts.csproj", "mcHahn.Contracts/"]
RUN dotnet restore "mcHahn.Contracts/mcHahn.Contracts.csproj"

COPY ["mcHahnAPI/mcHahn.Application/mcHahn.Application.csproj", "mcHahn.Application/"]
RUN dotnet restore "mcHahn.Application/mcHahn.Application.csproj"

COPY ["mcHahnAPI/mcHahn.Infrastructure/mcHahn.Infrastructure.csproj", "mcHahn.Infrastructure/"]
RUN dotnet restore "mcHahn.Infrastructure/mcHahn.Infrastructure.csproj"

COPY ["mcHahnAPI/mcHahnAPI/mcHahnAPI.csproj", "mcHahnAPI/"]
RUN dotnet restore "mcHahnAPI/mcHahnAPI.csproj"

COPY . .
WORKDIR "/src/mcHahn.Domain"
RUN dotnet build "mcHahn.Domain.csproj" -c Release -o /app/build

COPY . .
WORKDIR "/src/mcHahn.Contracts"
RUN dotnet build "mcHahn.Contracts.csproj" -c Release -o /app/build

COPY . .
WORKDIR "/src/mcHahn.Application"
RUN dotnet build "mcHahn.Application.csproj" -c Release -o /app/build

COPY . .
WORKDIR "/src/mcHahn.Infrastructure"
RUN dotnet build "mcHahn.Infrastructure.csproj" -c Release -o /app/build

COPY . .
WORKDIR "/src/mcHahnAPI"
RUN dotnet build "mcHahnAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mcHahnAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mcHahnAPI.dll"]