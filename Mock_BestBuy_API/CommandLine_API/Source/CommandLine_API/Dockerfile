# To build this Dockerfile, run the following command from the solution directory:
# docker build --file "Source\CommandLine_API\Dockerfile" --tag api .
# Or you can use the experimental buildx command for a better experience:
# docker buildx build --progress plain --file "Source\CommandLine_API\Dockerfile" --tag api .

# Base image used by Visual Studio at development time
# (See https://docs.microsoft.com/en-us/visualstudio/containers/container-msbuild-properties)
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
# Open Container Initiative (OCI) labels (See https://github.com/opencontainers/image-spec/blob/master/annotations.md).
LABEL org.opencontainers.image.title="Project Title" \
    org.opencontainers.image.description="Project Description" \
    org.opencontainers.image.documentation="https://github.com/Username/Project" \
    org.opencontainers.image.source="https://github.com/Username/Project.git" \
    org.opencontainers.image.url="https://github.com/Username/Project" \
    org.opencontainers.image.vendor="Project Author"
# Disable the culture invariant mode which defaults to true in the base alpine image
# (See https://github.com/dotnet/corefx/blob/8245ee1e8f6063ccc7a3a60cafe821d29e85b02f/Documentation/architecture/globalization-invariant-mode.md)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache \
    # Install cultures to enable use of System.CultureInfo
    icu-libs \
    # Install time zone database to enable use of System.TimeZoneInfo
    tzdata
# Set the default locale and language.
ENV LC_ALL=en_US.UTF-8
ENV LANG=en_US.UTF-8
WORKDIR /app
EXPOSE 80

# SDK image used to build and publish the application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS sdk
# To use the debug build configuration pass --build-arg Configuration=Debug
ARG Configuration=Release
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
WORKDIR /src
COPY "CommandLine_API.sln" "."
COPY "Source/CommandLine_API/*.csproj" "Source/CommandLine_API/"
COPY "Tests/CommandLine_API.IntegrationTest/*.csproj" "Tests/CommandLine_API.IntegrationTest/"
RUN dotnet restore
COPY . .
# To view the files that have been copied into the container file system for debugging purposes uncomment this line
# RUN apk add --no-cache tree && tree
RUN dotnet build --configuration $Configuration --no-restore
RUN dotnet test --configuration $Configuration --no-build
RUN dotnet publish "Source/CommandLine_API/CommandLine_API.csproj" --configuration $Configuration --no-build --output /app

# Runtime image used to run the application
FROM base AS runtime
WORKDIR /app
COPY --from=sdk /app .
ENTRYPOINT ["dotnet", "CommandLine_API.dll"]
