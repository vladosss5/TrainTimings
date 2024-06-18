FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5050
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TrainTimings.Api/TrainTimings.Api.csproj", "src/TrainTimings.Api/"]
COPY ["src/TrainTimings.Application/TrainTimings.Application.csproj", "src/TrainTimings.Application/"]
COPY ["src/TrainTimings.Core/TrainTimings.Core.csproj", "src/TrainTimings.Core/"]
COPY ["src/TrainTimings.Persistence/TrainTimings.Persistence.csproj", "src/TrainTimings.Persistence/"]
RUN dotnet restore "src/TrainTimings.Api/TrainTimings.Api.csproj"
COPY . .
WORKDIR "/src/src/TrainTimings.Api"
RUN dotnet build "TrainTimings.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TrainTimings.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrainTimings.Api.dll"]
