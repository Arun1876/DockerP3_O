#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["API_Work_DOCKER.csproj", ""]
RUN dotnet restore "API_Work_DOCKER.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "API_Work_DOCKER.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Work_DOCKER.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Work_DOCKER.dll"]