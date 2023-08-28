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























