FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry/AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry.csproj", "AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry/"]
RUN dotnet restore "AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry/AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry.csproj"
COPY . .
WORKDIR "/src/AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry"
RUN dotnet build "AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppRunner.AspNetCore6.HelloWorldWithOpenTelemetry.dll"]
