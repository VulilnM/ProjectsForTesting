FROM  mcr.microsoft.com/dotnet/aspnet:7.0 AS build-env
WORKDIR /app

COPY * .csproj./

COPY . ./
RUN dotnet publish -c Release -o out