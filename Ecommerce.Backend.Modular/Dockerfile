# Etapa 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solution e os projetos
COPY Ecommerce.Backend.Modular.sln ./
COPY Ecommerce.Backend.Modular/Ecommerce.API.csproj Ecommerce.Backend.Modular/
RUN dotnet restore Ecommerce.Backend.Modular/Ecommerce.API.csproj

# Copia todo o restante e compila
COPY . .
WORKDIR /src/Ecommerce.Backend.Modular
RUN dotnet publish Ecommerce.API.csproj -c Release -o /app/publish

# Etapa 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta (ajuste se necessário)
EXPOSE 80

ENTRYPOINT ["dotnet", "Ecommerce.API.dll"]