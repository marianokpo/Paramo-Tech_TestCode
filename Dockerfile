FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app
COPY . .
RUN dotnet restore

FROM build AS publish
RUN dotnet publish "src/Api/Sat.Recruitment.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Sat.Recruitment.Api.dll"]
