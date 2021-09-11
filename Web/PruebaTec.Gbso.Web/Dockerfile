#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PruebaTec.Gbso.Web/PruebaTec.Gbso.Web.csproj", "PruebaTec.Gbso.Web/"]
RUN dotnet restore "PruebaTec.Gbso.Web/PruebaTec.Gbso.Web.csproj"
COPY . .
WORKDIR "/src/PruebaTec.Gbso.Web"
RUN dotnet build "PruebaTec.Gbso.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaTec.Gbso.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaTec.Gbso.Web.dll"]