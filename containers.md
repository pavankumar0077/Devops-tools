# Devops-tools

REF LINK : https://github.com/pavankumar0077/Docker-Zero-to-Hero

Containers
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/db34edb3-6492-4be0-bdbc-3845dbfd94ba)

physical servers -- the problems with physical servers are solved by virtual machines to some extend.

Virtual machines or EC2 -- if we are not using completely then it is heavy loss for the organization
to solve this problem containers takes place.
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/5ce8c634-8a49-4682-bf09-9925bc240152)

NOTE: Virtual machines are very very secure than containers
-- VM's have a full OS that is they have complete isolation, where as containers do not have a complete OS
and they do not run their full OS, they is a logical isolation but it is not complete, there is one or other 
way to talk to the another container or each of this talk to the host OS to share some resources.

Architecuture of containers
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9d304046-f7d2-4ad5-8e07-b6ce681f1d88)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/f26ddea9-3419-4dd0-8f92-c31d587f3b97)

Life cycle of docker
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/628ccb18-da72-4fe4-b15b-8c7066a83d58)

Ex: Docker --> very much dependent on docker engine -- single point of failure
If docker engine is down then all the docker containers will stop working
conatiners will not responding

issues
--
--While creating docker images it will be created as layers it takes lots of storage on disk
--  single point of failure
-- and other issues

-- To avoid this issue -

BUILDAH
========
-- Buildah works with commands
-- works very well with podman, scopio
-- not need of dockerfiles 
-- write a shall script to create images
-- images can be docker image or any OCI image

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/84621d83-2c9f-45ce-a79a-5835e443532a)

containers do not have operating system
---
1) Containers have a base OS or they minimum system dependencies, This system dependencies are definictly required to form a logical isolation from one container to other container.
2) If the logical isolation is not there, or minimum dependencies are not there they however you manage to run the application on that specific conttainer, A Hacker who is entering into your container typically get into all of the containers and compressize the security of the organization.
3) /bin /sbin /etc /lib and etc these basic folders form a logical isolcation from one container to other container that means the container can not share these files and folders with other container, if these file and folders are sharing by the conatiner that me you are compresizing the security
4) This files are folders are using from the kernel they are basically part of the container base image

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







