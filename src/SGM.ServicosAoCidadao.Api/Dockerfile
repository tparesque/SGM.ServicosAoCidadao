#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SGM.ServicosAoCidadao.Api/SGM.ServicosAoCidadao.Api.csproj", "src/SGM.ServicosAoCidadao.Api/"]
COPY ["src/SGM.ServicosAoCidadao.Application/SGM.ServicosAoCidadao.Application.csproj", "src/SGM.ServicosAoCidadao.Application/"]
COPY ["src/SGM.ServicosAoCidadao.Repository/SGM.ServicosAoCidadao.Repository.csproj", "src/SGM.ServicosAoCidadao.Repository/"]
COPY ["src/SGM.ServicosAoCidadao.Domain/SGM.ServicosAoCidadao.Domain.csproj", "src/SGM.ServicosAoCidadao.Domain/"]
COPY ["src/SGM.ServicosAoCidadao.Core/SGM.ServicosAoCidadao.Core.csproj", "src/SGM.ServicosAoCidadao.Core/"]
RUN dotnet restore "src/SGM.ServicosAoCidadao.Api/SGM.ServicosAoCidadao.Api.csproj"

COPY . .
WORKDIR "/src/src/SGM.ServicosAoCidadao.Api"
RUN dotnet build "SGM.ServicosAoCidadao.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.ServicosAoCidadao.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.ServicosAoCidadao.Api.dll"]