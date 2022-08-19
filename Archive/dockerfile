FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build 

WORKDIR /app

COPY . .

RUN cd ./src/Alakazam.Basket.Web.Api/ && \
    dotnet publish -c release -r ubuntu.16.04-x64 -o publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app

COPY --from=build /app/src/Alakazam.Basket.Web.Api/publish .

ENTRYPOINT [ "dotnet","Alakazam.Basket.Web.Api.dll" ]


