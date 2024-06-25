# 1. Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /src

# restore
COPY src/OneReview/OneReview.csproj OneReview/
RUN dotnet restore OneReview/OneReview.csproj

# build
COPY src/OneReview/ OneReview/
WORKDIR /src/OneReview
RUN dotnet build OneReview.csproj -c Release -o /app/build

# 2. Publish
FROM build as publish
RUN dotnet publish OneReview.csproj -c Release -o /app/publish

# 3. Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5026
EXPOSE 5026
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneReview.dll"]
