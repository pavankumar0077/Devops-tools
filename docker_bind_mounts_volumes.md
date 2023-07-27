# Docker Bind Mounts & Volumes

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/b36deda7-7f22-42e8-bcf0-54777098cbd4)

Problems with containers
--
1) For example Container (Nginx) is running -- this nginx container will continously puts information about login info like IP address and other info and tries to store in a log file.

2) This logfile is imp, For security checks and last 10 days depending on the organization, time to time you 
perform auditing.

3) For suppose the container gone down, Because of container gone down, The log file will be deleted.
4) Containers are ephemeral or shortlived in nature
5) Container should not have a file system in nature

PROBLEMS (When we don't use mounts and volumes)
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0c0e40da-57ad-4228-9453-3fd446848a65)

   
# If container goes down, It used all of the resouces from host OS, but they are not a permanetly resources
for this container, If container goes down they free up the resources from OS and killed now the user details
or the logfile of the nginx is deleted.


# Example we have 2 containers 1 is front-end and 2nd is backend, The backend container will producer or sends 
html file to front end -- suddenly if backend container goes down then the generated files like today's yesterday's or 10 ago or one month ago files will be not available to front and front will only show which are
available like today's yesterdays files. Since we are not using persistence storage the information will be 
available.

# Assume we have one application, The whole purpose of the application is to read some file which is not on our
container, container reads the file that is provided from a CRON JOB on the HOST OS

TO SOLVE THE ABOVE PROBLEMS DOCKER HAS COME UP WITH 2 THINGS
BIND MOUNTS
VOLUMES
--
# BIND MOUNTS

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/d06f1c53-c1c1-4cbd-a505-e00a5c413418)

1) It allows to Bind a directory inside the container
2) It will bind a floder on our container with folder on the HOST
3) Any folder that is /app folder can be read the container, Container will read or write to that specific dir
4) If the container goes down, The /app dir is also present in the HOST when ever a new container comes up
called C2 now again bind the same /app folder, So that the information is not lost, Whenever container is come up it already has the information
5) Even if container is not coming up the user information or whatever data is present in the HOST will be available.

# VOLUMES 

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/f29fe7d3-2327-41a9-8e8c-ac70c3db0675)

Volumes also do some job, But have a better life cycle
1) Use docker cli we can use volumes, Volumes are nothing logical partition that we are creating in the HOST
2) Create, destory, attach, attach the same volume to one more containers
3) Attaching specific folder or a specific file sytem to a container, But he main advantage is we are not providing dir details like /app dir, Instead we are saying create a volume on the HOST
4) This volume basically a logically partition on a HOSTd
5) Logical volume will be mounted to the conatiner
6) We are managing the entire volumes using docker cli it self.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/35400b43-23a0-4f6b-bb76-766bedcc19a0)

8) If we are using bind mounts then we are restricted to use only that particular dir, But if we are using
volumes, we can create volume on any place like same HOST, External EC2 instance, any external storage devices like S3 buckets or NFS not restriction we have lot of options, externnal sources
9) Like bind mounts, we don't have to play directly use with the when container is running, Instead we can manage it life cycle by docker commands
10) Docker docker volume, docker volumes ls -- commands
11) This volumes can easily shared from one container to other container
12) This volumes can be high performance as well

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/083f843f-1152-4c1c-ac88-702376aab7de)

1) docker -v == If we are using -v that means we define the arguments like source; dest; temp ;parmanent storeage;
2) docker --mount == Detailed commadnd like source == source
   2.1) storage == storage
   2.2) etc
3) The above 1 and 2 commands are same just syntax is different.

 





