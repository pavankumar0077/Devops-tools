Docker
--
```
Contanierization is a concept or technology and docker implements containerization.
```

Podman
--
```
Podman is very good competiter for docker
Podman addresses few complicated problems of docker, docker is centerized and it has only one docker deamon
```

Next level tools after docker
---
Bildah
Podman
Skopeo


Docker Architecture
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/95632d23-eeb9-4ca3-a921-894443dd9452)

Docker daemon -- It is process we gonna install whenever we installed docker it is actually installing the docker daemon heart of docker is docker daemon. If docker deamon goes down technically docker conatiners will stop working 
--
1) Whenever we are cli commands they are received by docker deamon and executed, and create continers, images using this we can push images to docker registry

Docker lifecycle
--
Dockerfile 
    |
Docker image
    |
Docker conatiner

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/5d9ec0ad-fd70-4a43-ad41-e4fcc87edc0d)

Docker public registry
--
Docker Hub 
Quay.io 

Difference Github & Docker hub
--
Github is used to store source code, It is a VCS of our platform
Dockerhub is version control platform for docker images 

Docker file example
--
FROM ubuntu: latest
# Set the working directory in the image
WORKDIR /app

# Copy the files from the host file system to the image file system
COPY./app

# Install the necessary packages
RUN apt-get update && apt-get install -y python3 python3-pip

# Set environment variables
ENV NAME World

# Run a command to start the application
CMD ["python3", "app.py"]

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/2014b29c-e509-47d1-9cf7-a48a4bb70ec8)

Push images to registry docker hub
--

```
docker login

docker push pavankumar0077/my-app:latest

username / app-name : tag 
```
```
Entrypoint -- This commands serves as a start command, It cannot be changed, wheenever you are running container, they can not override this value in docker image where as CMD is something configurable.
-- Main executable should be in Entrypoint and it is not changable
-- If users wants to change parametes or modify existing paramentes then use CMD
-- One thins must be same for example python3 is used to run any python script -- this should be entry in entrypoint
```

port mapping for docker images
--
```
Ex: sudo docker run -p 8000:8000 -it <img-id>
-p -- port 
8000 -- left side is container port
8000 -- right side is host port
-it -- interactive mode  -- It show the logs and other stuff

-- It may not be same as container port for host port
Ex: 7688:8000

Expose the port in AWS
--
instance settings 
security group
inboud rules
apply port 8000 to run the application -- custom tcp -- source everywhere or use only your ip

```








