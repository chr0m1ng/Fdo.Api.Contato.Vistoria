FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Fdo.Api.Contato.Vistoria.Facades/Fdo.Api.Contato.Vistoria.Facades.csproj", "Fdo.Api.Contato.Vistoria.Facades/"]
COPY ["Fdo.Api.Contato.Vistoria.Models/Fdo.Api.Contato.Vistoria.Models.csproj", "Fdo.Api.Contato.Vistoria.Models/"]
COPY ["Fdo.Api.Contato.Vistoria.Services/Fdo.Api.Contato.Vistoria.Services.csproj", "Fdo.Api.Contato.Vistoria.Services/"]
COPY ["Fdo.Api.Contato.Vistoria/Fdo.Api.Contato.Vistoria.csproj", "Fdo.Api.Contato.Vistoria/"]

RUN dotnet restore "Fdo.Api.Contato.Vistoria/Fdo.Api.Contato.Vistoria.csproj"
COPY . .
WORKDIR "/src/Fdo.Api.Contato.Vistoria"
RUN dotnet build "Fdo.Api.Contato.Vistoria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fdo.Api.Contato.Vistoria.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fdo.Api.Contato.Vistoria.dll"]