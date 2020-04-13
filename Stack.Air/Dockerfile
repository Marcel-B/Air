#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 13.x
# see https://github.com/nodesource/distributions/blob/master/README.md#deb
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

COPY Stack.Air.csproj Stack.Air/
RUN ls Stack.Air/
RUN dotnet restore "Stack.Air/Stack.Air.csproj"
COPY . "./Stack.Air"
WORKDIR "/src/Stack.Air/ClientApp"
RUN npm install
RUN npm run-script build

WORKDIR "/src/Stack.Air"
RUN dotnet build "Stack.Air.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stack.Air.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stack.Air.dll"]
