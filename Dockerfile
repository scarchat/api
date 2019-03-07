FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Scar.Api/Scar.Api.csproj", "src/Scar.Api/"]
RUN dotnet restore "src/Scar.Api/Scar.Api.csproj"
COPY . .
WORKDIR "/src/src/Scar.Api"
RUN dotnet build "Scar.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Scar.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Scar.Api.dll"]
