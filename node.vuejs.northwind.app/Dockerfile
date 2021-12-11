# Specifies which OS to use. Here it is unix OS pre-installed with node v-12
FROM node:12-alpine
LABEL developer=bibhup_mishra@yahoo.com
MAINTAINER Devops Engineer(bibhup_mishra@yahoo.com)
RUN mkdir -p /app 

# copy source files from host computer to container
COPY . /app/


# Set working directory within the image. Paths will be relative this WORKDIR. 
WORKDIR /app


# Install dependencies and build app
RUN npm install 

# Specify port app runs on
EXPOSE 9095

# Set environment variable default value
#ENV DATABASE_HOST="devopsmasterlinuxvm.centralus.cloudapp.azure.com" \
#DATABASE_SRV=false \
#DATABASE_PORT=9003 \
#DATABASE_NAME=strapicms \
#DATABASE_USERNAME=mongoadmin \
#DATABASE_PASSWORD="passw0rd!" \
#AUTHENTICATION_DATABASE="" \
#DATABASE_SSL=false


# Run the app
CMD [ "npm", "run", "serve" ]
