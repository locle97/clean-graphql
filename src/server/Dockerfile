FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY *.sln .
COPY  ./CleanGraphQL.GraphQL/CleanGraphQL.GraphQL.csproj ./CleanGraphQL.GraphQL/
COPY  ./CleanGraphQL.Application/CleanGraphQL.Application.csproj ./CleanGraphQL.Application/
COPY  ./CleanGraphQL.Infrastructure/*.csproj ./CleanGraphQL.Infrastructure/
COPY  ./CleanGraphQL.Core/*.csproj ./CleanGraphQL.Core/
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
COPY --from=build app app
WORKDIR /app
EXPOSE 8080
ENTRYPOINT ["dotnet", "CleanGraphQL.GraphQL.dll"]
