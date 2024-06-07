FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CapitalGain.App/CapitalGain.App.csproj", "CapitalGain.App/"]
RUN dotnet restore "./CapitalGain.App/CapitalGain.App.csproj"
COPY . .
WORKDIR "/src/CapitalGain.App"
RUN dotnet build "./CapitalGain.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CapitalGain.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalGain.App.dll"]