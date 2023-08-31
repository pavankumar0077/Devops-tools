# DOCKER COMPOSE FILE

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/a2733e1f-dce7-4706-bcc6-4017f7441741)

# Here we can see that we have dockerfile for both user-service and department-service 
1) Both user-service and department-service are having intercommmunication to exchange of from one microservice
to another microservice

user-service dockerfile
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ba3acdc3-9088-4597-8780-0a4f78dde45a)

department-service dockerfile
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/4d1174a8-430f-4c4d-94d6-ffa9ee891ba5)

docker-compose for the above services
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/267d554b-bf95-4d12-ae32-06ef8930fc8b)

Check docker-compose config or define it
--
``` sudo docker-compose config ```
NOTE: If we are in base dir, then we don't need to specific any file info here - it will search bydefault for
the docker-compose.yaml file and it will execute it

To check docker-compose
--
``` sudo docker-compose build ```

To start the services 
--
``` sudo docker-compose up ```
``` sudo docker-compose up -d ``` Detach mode backgroud

To check the running services
--
``` sudo docker-compose ps ```

To check images
--
``` sudo docker-compose images ```

Create custom image name 
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/eeb32214-a3f9-4aff-a412-1733a11f1df0)

We can build and up the service in one command
--
``` sudo docker-compose up -d --build ```

Start, stop, kill the sevices
--
``` sudo docker-compose stop <container-name> ```
If container is not specified it will stop all the services

``` sudo docker-compose start ```

``` sudo docker-compose restart ```

``` sudo docker-compose kill ```

Check logs
--
``` sudo docker-compose logs ```

``` sudo docker-compose  logs <container-id>  or <container-name>```

To get all docker-compose commands
--
``` sudo docker-compose help ```

To check running servides 
--
``` sudo docker-compose top ```

To exec into conatiner
--
``` sudo docker-compose exec <container-name> bash ```

Varibles in docker-compose 
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/b0ec95ca-a324-40fd-a4e9-861b277bfba6)

In the above image we are using openjdk:11 version 
1) All the env varibles that we are using in dockerfile are should be externalized those information can be
stored in anyfile and passed.
2) We can add the variables in dockefile and pass to docker-composse file 

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/29f5b546-2fd4-4e0a-8e15-a5b5d7d21037)

Now this information is passed to dockerfile

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0ab4a8ae-b390-49a0-a39d-0c6e05a073ba)

**In this way we can pass the env varibles, config varibles also. So in this we can build the DYNAMIC 
docker-compose files**


NOTE : IN COMPOSE FILE WE HAVE IMAGE TAG : IMAGE CAN BE TAKEN FROM DOCKER HUB AS WELL

State of the docker-compose file
--
1) Whatever we define in the docker-compose file that should be desired state of our service or application
2) We change the state of any of the services then docker engine will check the state available and
do the changes only abilicable (Only check in the modified services)
3) ![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0cf6e810-0159-4dd3-b42c-ca685736db8a)
4) Here we are changing the port of the dept-service, Now checking for changes ``` sudo docker-compose up -d ``` only re-created dept-service not user-service, As we only modified dept-service

# NOTE: Docker-compose is only used in a single host machine, we don't run on the differnt host machine all conatiners will be in single host machine. If we want multiple conatiners in differnethost machine then will have DOCKER-SWARM. So this is the disadvantage  of using docker-compose 

Push to dockerhub
--
Login
``` sudo docker login ```

Push
``` sudo docker-compose push ``` To push the all images present in local

Pull
``` sudo docker-compose pull ``` To pull the images from the docker hub
Before pulling create the dir's, specified in the docker-compose file like user-servie and depart service

``` sudo docker-compose up ``` To up the services 

Override docker-compose file
--
1) So in prod we have multiple - docker files the default file name is docker-compose.yaml when we are using this then we are not have to give any file info flag in command
2) docker-compose.override.yaml - the docker-compose file will be base file for the all the configurations it will find the docker compose from base dir 1st it will configure according to docker-compose file
3) From the override file it will also the run the override file and it will override the settings from that particular override file

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/e711dc86-a3e6-4e09-ad75-73e319d9824a)

4) Now if we go to docker-compose ``` sudo docker-compose up -d ```, You can see the new image for
the service from ther override file ``` sudo docker-compose images ```

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/6a068853-d9d0-4e08-ac71-401b540940bc)

Now we have change the port number, the changes are append so make sure to check the changes carefully
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/4eab5f61-69a6-4009-8ea5-8df9bc38295f)

Generally in differnet - different we give different names like
docker-compose.prod, stage, testing, etc

To up and down the multiple docker-compose files
--
``` sudo docker-compose -f .\docker-compose.yml -f .\docker-compose.ovveride.yaml up -d ```

``` sudo docker-compose -f .\docker-compose.yml -f .\docker-compose.ovveride.yaml down -d ```


``` ===============================================================================  ````

Install docker-compose 
--
In linux we have aready docker-compose for other OS, install it ``` https://docs.docker.com/compose/install/ ```

Remove docker images
--
1) We generally remove images by using ``` sudo docker image rm image-1 image-2 ... ```
2) How to get all images id's ``` sudo docker images ls ``` Where we are getting all images, But if we use
``` sudo docker ls -q ``` then we will only get image-id's. Now we can pass this as an argument to docker remove command
3) ``` sudo docker image rm $(sudo docker image ls -q) ``` If we run this we will get error because some of the containers are running or stopped containers. So we always remove containers first.
4) ``` sudo docker container rm  -f $(sudo docker container ls -aq) ``` Here -a to being stopped conatiners are well and -q to get the only id's of the containers.
5) To remove all the images ``` sudo docker image rm -f $(sudo docker image ls -q)```






























