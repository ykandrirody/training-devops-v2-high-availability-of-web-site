FROM microsoft/aspnet:1.0.0-rc1-update1

EXPOSE 80
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY . /app/
WORKDIR /app
RUN ["dnu", "restore"]
