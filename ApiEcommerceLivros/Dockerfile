FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiEcommerceLivros/ApiEcommerceLivros.csproj", "ApiEcommerceLivros/"]
RUN dotnet restore "ApiEcommerceLivros/ApiEcommerceLivros.csproj"
COPY ./ApiEcommerceLivros ./ApiEcommerceLivros
WORKDIR "/src/ApiEcommerceLivros"
RUN dotnet build "ApiEcommerceLivros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiEcommerceLivros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./CounterPage/build ./wwwroot

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet MApiEcommerceLivrosyApi.dll