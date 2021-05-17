# For the build pipeline.
ARG BuildNumber

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish
ARG BuildNumber
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish "./Example.SenderReceiver/Example.SenderReceiver.csproj" -p:Version=${BuildNumber} -c Release -o /app --no-restore

FROM  mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
EXPOSE 443
EXPOSE 5000
ENTRYPOINT ["dotnet", "./Example.SenderReceiver.dll"]
