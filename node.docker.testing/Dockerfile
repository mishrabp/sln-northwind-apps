# Specifies which OS to use. Here it is unix OS pre-installed with node v-12
FROM ubuntu:kinetic-20220830
LABEL developer=bibhup_mishra@yahoo.com
MAINTAINER Devops Engineer(bibhup_mishra@yahoo.com)
RUN apt-get update -y && \
    mkdir -p /app 

# copy source files from host computer to container
#COPY ["package.json", "package-lock.json*", "./"]
COPY . /app/
#ADD . .


# Set working directory within the image. Paths will be relative this WORKDIR. 
WORKDIR /app


# Run the app
#CMD [ "ls" ]
