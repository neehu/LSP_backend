FROM microsoft/dotnet:1.0.12-runtime
ENV ASPNETCORE_URLS http://+:80
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
EXPOSE 80 