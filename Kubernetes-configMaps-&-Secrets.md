# KUBERNETES CONFIGMAPS  & SECRETS

Passwords and other stuff
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/844ca462-be14-463b-8cac-a8aeeb9811d7)

1) In general we have front-end back-end and a DB for any of the application
2) the back-end application needs some data related to DB connections like user-name, password, port, url and etc to
3) connect to Db, for data
4) We create these data NOT LIKE HARD-CODED,but we use like EVN variables to store the DB related info or we use a file
5) to store all these data in the file system and we input it when requried using OS mdules based on the programming language
 
# THE ABOVE PROCESS GENERAL PROCESS, BUT HOW WE USE THE SAME THING IN KUBERNETES

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9d94d7a1-6406-4a70-b94e-dec69b49bb07)

1) DB port, DB connection type -- as we kubernetes deals with the containers -- containers get the data
  from Env variables or File So to acheive this kubernetes supports **CONFIG-MAPS**
2) As a DevOps engineer or Config-mananger administator we can create a Configmap inside the kubernetes cluster
and put the info like DB port, DB connection type and etc and we can mount this configmap to the container or use
the details of the config-map inside yours kubernetes POD 
3) The information can be stored inside the POD as a ENV variable or can be stored as a FILE in the container file system
But these information must be retrived from the config-map be'coz as a user we can cannot go in to the pod
and create the ENV variable we can do this but it is not right, may be fields like changed or other issues
4) Whenever we are creating DOCKERFILE we don't know these values, these values are feed to the applicaiton
later point of time
5) KUBERNETES SUGGEST GO WITH THE CONFIG-MAP
6) As a DEVOPS enginner we have to collect the info that a user requires -- we can talk to DB admin and
we have to CREATE a Config-Maps and stored it.
7) Then we can mount this config-map, we can use this data of config-map as ``` 1st way ENV variables inside our kubernetes
pod 2nd way we can use it as volume mounts ```

NOW THE DB OR CONFIG INFO PROBLEM IS SOLVED BY CONFIG-MAP, WHEN WHY WE HAVE SECRECTS IN KUBERNETES
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/49b08daa-215c-467b-8de5-4bff402433d2)

1) SECRETS deals with sensitive data (Like DB username, DB pwd), If we try to keep these details with
config-map, then we have a major problem with kubernetes that is, In kubernetes whenever we created a resource
whats happens is THIS INFORMATION GETS STORED IN **ETCD** . In ETCD the data is saved as objects
if any hacker tries to hack the ETCD, and if he got the DB-username and pwd that is entrie application
or platform is compramsed and database access
2) **KUBERNETES SAY IF WE HAVE NON-SENSITIVE DATA THEN SAVE IT IN A CONFIG-MAP, BUT IF WE HAVE SENSITIVE DATA
THEN SAVE IT AS SECRETS.**
3) How secrets are safe, Whatever data we put in secrets it will ENCRYPT the data in the REST, before the object
saved in ETCD, KUBERNETES will encrypt it. Bydeault kubernetes uses basic encrytpion and their is a option
for custom encryption as well.

LETS DEEPDIVE into this
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ba81f095-8f8d-4b42-8a60-93536b9c3c06)

1) USER created a config-map using yaml file and we have created it by kubectl apply -f and it got created
2) At the same time **API SERVER saving this information inside the ETCD as well.**
3) Now if hacker has cluster access, he can do kubectl describe or edit command and DB password will be comparmized, a
and even he can go to ETCD and get the info required.
4) In the above point we can see the problem
   4.1) Secrets -- Hacker might use same approach like point no.3 like describe or edit
   4.2) ETCD -- ecrypted so not possible to hack be,coz hacker does not have de-ecryption key
5) KUBERNETES is saying whenver you are creating SECRETS use a STRONG RBAC ( Least previllege -- give only to who actuall requirred this info )

Commands
--
To get the config-map
--
```
kubectl get cm
```
To describe cm
--
```
kubectl describe cm test-cm
```
To apply cm or create
--
```
kubectl apply -f cm.yml
```
To get env info present in the container
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/39770d25-b15e-4dc9-8d5e-826c182b7f88)

```
kubectl exec -it sample-python-app-6fd477bdfb-pkps4 (pod-name) -- /bin/bash
```
To check the env variables
--
Inside the pod
```
env | grep db
```
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/716622eb-cef1-4f0d-8f29-514eaf165850)

NOTE: Now we can see that PORT Numer, So developer import it using os modules like 
```
os.env("DB-PORT") -- in case of python application
``
The above approach is good, but we have problem here
1) For some reason if we change the PORT number in CM.yaml file
2) The application will still have old port number, So the application will not work
3) Pod will not know that port number is changed

**TO SOLVE THE ABOVE ISSUE KUBERNETES SAID (Changing the env variable inside the kubernetes is not possible inside containers is not possible.**

**To SOVE WE HAVE TO USE VOLUME MOUNTS**
 --
 1) Container does not allow to change the port number, we have re-create  the container
 2) But in prod env  we can not do that in conatiner, bec'coz it will may lose the traffic
```
USEING VOLUME MOUNTS
--
1) Instead of using env variables, Config-Map info will be saved in file and Dev's will use the file.
2) 
