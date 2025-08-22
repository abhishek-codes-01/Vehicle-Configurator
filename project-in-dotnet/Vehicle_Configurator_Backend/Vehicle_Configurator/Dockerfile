FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5042
EXPOSE 7027
ENV ASPNETCORE_URLS="http://+:5042;https://+:7027"
ENTRYPOINT ["dotnet", "Vehicle_Configurator.dll"]
