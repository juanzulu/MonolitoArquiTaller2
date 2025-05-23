# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://0.0.0.0:80

# Etapa build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

COPY ./sql/init.sql ./sql/init.sql

ENTRYPOINT ["dotnet", "monolitoTaller.dll"]

CMD ["dotnet", "monolitoTaller.dll"]
