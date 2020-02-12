# Blog

## Goals

1. Experience creating, setting up and managing an ASP.NET Core application with authentication using a document database.

2. Experience setting up a database inside a Docker container for application development.

3. Experience deploying an application to Google Cloud Run (web app, database solution, file storage).

4. Develop a functional Markdown based blog application for personal use.

## Side goals

1. Use as little JavaScript as possible.

## Tech choices

ASP.NET Core, MongoDB, Docker, Google Cloud Run.

## Development

### Database

#### Starting for the first time

1. Execute `docker pull mongo` to pull MongoDB image from the Docker Hub.

2. Execute `docker run -d --name mongoblogdevelop -p 27017:27017 mongo` to create and start a container named "mongoblogdevelop".

#### After the first time

1. Execute `docker start mongoblogdevelop`.