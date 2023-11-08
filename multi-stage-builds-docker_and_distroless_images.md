```Multi stage Builds ```
```Distroless```


Multi-Stage Buids
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c5116680-f5b5-4cce-af5d-d8b1dbe59db7)

This is a simple docker file but here as we can use lof of things that are not used to run the application like we are using 
ubuntu which comes with a lot of files and there are lot of unnecessary things that are not even used and it results in 
increase in the image size.

To fix this issue Docker introduced Multi stage builds
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/cc2c6ba6-e8b5-4abc-941a-db0f9959c013)


```
Split the docker file in multii parts
=====================================
-- In the stage 1 the docker files will be as but we dont write entrypoint and cmd 
-- from stage 1 we will take only binary or docker image or from stage 1 docker file 
-- The docker image form stage 1 will be placed in stage 2 
-- both stage 1 and stage 2 will remain in one dockerfile only
-- But we have two FROM statements.
-- In stage the FROM -- will have to choice very minimal image, like image that have only python runtime or java 
or etc basically very less size image, or distrolless images
-- In the stage 2 or final srage we have ENTRYPOINT OR CMD, The advantage with this is we have reduced image size 
significantly so stage 1 content will not be in the final image.
-- Here stage 1 is the build image part
-- Stage 2 will be the final image, it has run time, image form stage 1 and entry point.
```


FOR EXAMPLE: 3 trie application
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/1de865fa-093c-41ca-88fb-20452a8bb820)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c61b89fc-2955-4b36-9ff3-b837017fc420)


NOTE -- Dockerfile has n number of stages but final stage should have only one minimalistic image which has entrypoint or cmd 


DISTROLESS DOCKER IMAGE
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/a7686eab-01b0-4353-97af-7adc97a5ec59)

```
-- It is very lightweight images, that will have only runtime env
-- It is very minimalistic image, that will hardly have any packages
-- For example if we take python distroless image that have only python runtime 
-- Statically runtime images that don't required runtime env ecample golang
-- it will reduce docker image for very very less size like 10mb or 15mb
-- Bigest advantage from distroless images are we get security, reduce the size and security with distroless images
-- If we use distroless images 99% it will not expose for any security vulnerability
```

To get only atleast 5 images and old
```
sudo docker images | head -5


sudo docker images | tail -5
```

Multi-stage build
--
1) Stage 1 -- Here we don't have entrypoint or cmd
-- This stage only for build steps
-- It will only create the binary of the image
   
3) Stage 2
-- special image called ```scratch``` (which is minimalistic distro-less image)
   this is only for go lang.
   If we need scratch kind of image then we have to install python or java on upto of it scratch or find
   distro-less images of python and java

Example fo normal dockerfile
--
```
###########################################
# BASE IMAGE
###########################################

FROM ubuntu AS build

RUN apt-get update && apt-get install -y golang-go

ENV GO111MODULE=off

COPY . .

RUN CGO_ENABLED=0 go build -o /app .

ENTRYPOINT ["/app"]

```

NOTE: SIZE OF THE DOCKER IMAGE AFTER BULIDING IS 

1) simplecal            latest           b38a0fb1b970   7 days ago      862MB


Example of Multi-stage-build dockerfile for Go lang appliication
--
```
###########################################
# BASE IMAGE
###########################################

FROM ubuntu AS build

RUN apt-get update && apt-get install -y golang-go

ENV GO111MODULE=off

COPY . .

RUN CGO_ENABLED=0 go build -o /app .

############################################
# HERE STARTS THE MAGIC OF MULTI STAGE BUILD
############################################

FROM scratch

# Copy the compiled binary from the build stage
COPY --from=build /app /app

# Set the entrypoint for the container to run the binary
ENTRYPOINT ["/app"]

```

NOTE: SAME IMAGE WITH MULTI-STAGE BUILD AND THE SIZE IS
1) simplecal-multistage                            latest           b6ef14e24e5e   3 minutes ago   1.83MB

MULTI-STAGT-BUILD OR DISTRO LESS IMAGES ARE HAVE GOOD SECURITY AND LESS VILNERBILE 

Find distroless images
--
Use this link 
``` https://github.com/GoogleContainerTools/distroless ```
Ex: instead of scratch use gcr.io/distroless/java17-debian11 for java 




   
