FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppRunner.AspNetCore6.HelloWorld/AppRunner.AspNetCore6.HelloWorld.csproj", "AppRunner.AspNetCore6.HelloWorld/"]
RUN dotnet restore "AppRunner.AspNetCore6.HelloWorld/AppRunner.AspNetCore6.HelloWorld.csproj"
COPY . .
WORKDIR "/src/AppRunner.AspNetCore6.HelloWorld"
RUN dotnet build "AppRunner.AspNetCore6.HelloWorld.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "AppRunner.AspNetCore6.HelloWorld.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppRunner.AspNetCore6.HelloWorld.dll"]
