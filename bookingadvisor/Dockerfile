FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY bookingadvisor/*.csproj bookingadvisor/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src/bookingadvisor
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "bookingadvisor.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet bookingadvisor.dll