# ------------ STAGE 1 : build ------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos apenas os arquivos de projeto primeiro (cache das camadas)
COPY *.sln .
COPY API/*.csproj ./API/
COPY Domain/*.csproj ./Domain/
COPY Ecommerce.Application/*.csproj ./Ecommerce.Application/
COPY Ecommerce.Infrastructure/*.csproj ./Ecommerce.Infrastructure/
COPY Ecommerce.Stock.Application/*.csproj ./Ecommerce.Stock.Application/
COPY Ecommerce.Stock.Consumer/*.csproj ./Ecommerce.Stock.Consumer/
COPY Ecommerce.Stock.Domain/*.csproj ./Ecommerce.Stock.Domain/
COPY Ecommerce.Stock.Infrastructure/*.csproj ./Ecommerce.Stock.Infrastructure/
COPY Ecommerce.Worker/*.csproj ./Ecommerce.Worker/
# (adicione mais linhas se criar novos projetos)

RUN dotnet restore

# Agora o restante do código
COPY . .

# Publica só a API (e todas as libs dependentes) em Release
RUN dotnet publish API/Ecommerce.API.csproj \
    -c Release -o /app/publish -p:UseAppHost=false

# ------------ STAGE 2 : runtime ------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta padrão Kestrel
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet","Ecommerce.API.dll"]