FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["YouLearn.API/YouLearn.API.csproj", "YouLearn.API/"]
RUN dotnet restore "YouLearn.API/YouLearn.API.csproj"
COPY . .
WORKDIR "/src/YouLearn.API"
RUN dotnet build "YouLearn.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "YouLearn.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "YouLearn.API.dll"]