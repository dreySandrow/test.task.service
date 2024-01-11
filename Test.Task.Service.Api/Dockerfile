FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Test.Task.Service/Test.Task.Service.csproj", "Test.Task.Service/"]
RUN dotnet restore "Test.Task.Service/Test.Task.Service.csproj"
COPY . .
WORKDIR "/src/Test.Task.Service"
RUN dotnet build "Test.Task.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.Task.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Task.Service.dll"]
