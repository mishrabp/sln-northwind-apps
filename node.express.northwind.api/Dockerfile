# Specifies which OS to use. Here it is unix OS pre-installed with node v-12
FROM node:12-alpine AS base
LABEL developer=bibhup_mishra@yahoo.com
MAINTAINER Devops Engineer(bibhup_mishra@yahoo.com)
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM node:12-alpine AS publish
WORKDIR /src
COPY node.express.northwind.api/package*.json .
# Install dependencies and build app
RUN npm install 
# Bundle app source
COPY node.express.northwind.api/. .


FROM base AS final
COPY --from=publish /src .
# Set environment variable default value
#ENV DATABASE_HOST="devopsmasterlinuxvm.centralus.cloudapp.azure.com" \
# Run the app
CMD [ "npm", "start" ]
