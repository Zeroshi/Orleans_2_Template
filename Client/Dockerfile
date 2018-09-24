FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Client/Client.csproj Client/
COPY Contracts/Contracts.csproj Contracts/
COPY Grains/Grains.csproj Grains/
COPY Silo/Silo.csproj Silo/
RUN dotnet restore Contracts/Contracts.csproj
RUN dotnet restore Grains/Grains.csproj
RUN dotnet restore Silo/Silo.csproj
RUN dotnet restore Client/Client.csproj
COPY . .
WORKDIR /src/
RUN dotnet build Client.csproj -c Release -o /app
RUN dotnet build Contracts.csproj -c Release -o /app
RUN dotnet build Grains/Grains.csproj -c Release -o /app
RUN dotnet build Silo/Silo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Client.csproj -c Release -o /app
RUN dotnet publish Contracts.csproj -c Release -o /app
RUN dotnet publish Grains/Grains.csproj -c Release -o /app
RUN dotnet publish Silo/Silo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Client.dll"]
