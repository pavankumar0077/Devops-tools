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





