FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch as build-env
WORKDIR /code
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Realease -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
WORKDIR /app
COPY --from=build-env /code/out ./

EXPOSE 80
ENTRYPOINT [ "dotnet","User.API.dll" ]