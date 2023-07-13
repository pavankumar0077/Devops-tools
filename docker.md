Docker
--
Contanierization is a concept or technology and docker implements containerization.

Podman
--
Podman is very good competiter for docker
Podman addresses few complicated problems of docker, docker is centerized and it has only one docker deamon 

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




