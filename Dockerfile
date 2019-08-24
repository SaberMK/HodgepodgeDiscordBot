FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
# WORKDIR /app

# Copy csproj and restore as distinct layers

# COPY *.sln ./
# RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:2.2
ENV token=
ENV cmdPrefix=
# WORKDIR /app
# RUN ls -la 
# RUN pwd
COPY --from=build-env /HodgepodgeDiscordBot/out .
# ENTRYPOINT ["dotnet", "HodgepodgeDiscordBot.dll"]
CMD ["dotnet", "HodgepodgeDiscordBot.dll"]