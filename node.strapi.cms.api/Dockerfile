# Specifies which OS to use. Here it is unix OS pre-installed with node v-12
FROM node:12-alpine AS base
LABEL developer=bibhup_mishra@yahoo.com
MAINTAINER Devops Engineer(bibhup_mishra@yahoo.com)
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM node:12-alpine AS build
WORKDIR /src
COPY package*.json .
# Install dependencies and build app
RUN npm install 



FROM build AS publish
# Bundle app source
COPY . .
RUN npm run build


FROM base AS final
COPY --from=publish /src .
# Set environment variable default value
ENV DATABASE_HOST="devopsmasterlinuxvm.centralus.cloudapp.azure.com" \
DATABASE_SRV=false \
DATABASE_PORT=30090 \
DATABASE_NAME=strapicms \
DATABASE_USERNAME=strapiuser \
DATABASE_PASSWORD="passw0rd!" \
AUTHENTICATION_DATABASE="strapicms" \
DATABASE_SSL=false
# Run the app
CMD [ "npm", "start" ]


