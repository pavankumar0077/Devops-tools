# KUBERNETES RBAC (Role based access control)

User managment and services that are running in the cluster
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/15611af7-a176-4483-8370-058d0a6ed40c)

RBAC Can we divided into two parts
# Users
1)We are using kubernetes clusters in Minikube or anyother platform like kind, out of the box
we will get adminstrative access (Be'coz it is running in local), But when we try to use kubernetes in
Organization, the 1st thing we do is define access as a devops engineer 
2) Depending on the role we will define access

# Servuce accounts
1) We have created a POD, what access this pod should have in the kuberntes cluster like should POD
Be having the access to config maps, or secrets as part of the application we need to read config-map
2) This pod is deleting some content related to API server, accidently removing some imp files in the
system
3) Similar to user-management we can also manage the access for your services or the application which
are running the cluster using RBAC
   
IN KUBERNETES WE HAVE 3 MAJOR THINGS FOR MANAGING RBAC
--
1) Service accounts/Users
2) Kubernetes roles/Cluster roles
3) Role binding/Cluster role binding

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/92c7426c-ac37-4a85-a3f6-25dfe9a372c9)

These are the high level 3 things that will define the RBAC's in kubernetes
**NOTE: KUBERNETES DOES NOT DEAL WITH THE USER MANAGEMENT, It off loads to IDENTITY PROVIDERS**

**Ex: For example now-a-days if we downloaded an application from playstore, mostly of the application while
singin or singup there is option as LOGIN WTIH GOOGLE. Some thing kubernetes also do.**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/41df3871-94a1-4784-a3fd-a5122732999c)

** IN KUBERNETES API- SERVER WORKS AS OAUTH SERVER WE CAN OFF LOAD USER MANAGEMENT TO ANY IDENTITY PROVIDERS
SOME OF THE IDENTITY PROVIDERS ARE
A) IF we are using AWS - EKS cluster then use IAM users, using IAM users you can login to cluster in between we have
create someting called IAM OAUTH PROVIDER 
B)LDAP
C) OKTA
D) SSO 
Depending on the organization
** We can also use KEYCLOCk (Using keyclock as a broker we can connet to cluster)
** EKS cluster at amazon, integrate EKS with key clock and using key clock we can connect it our github, in github
we can create user-managment and collab accordingly

SERVICE ACCOUNTS -- Can be created as simple like pod.ymal files 
--
1) serviceaccount.ymal file
2) Bydefault whenever you are running POD it comes with a default service account, it gets created automatically
3) Using this service account kubernetes pod/application will be talking to API server
4) For connecting with any resources in kubernetes it will use the service accounts itself
5) If you are not creating a service account kubernetes will create a default service account and it will attach to our pod
6) if we are creating service account when we can use our custom service one

AFTER THIS HOW DO WE MANAGE THE RULES OR CONFIGURATIONS
--
7) To defined access after the above steps, kubernetes supports 2 important resources that is
**ROLE/Cluster role,
role binding/cluster role binding**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/8fb28520-7d86-48a5-8304-c2249b6b25a6)

9) Firstly we creat a role and then we will access this to the developers like says, they should have access to pod,
config-maps, secrets with in the same namespace
10) To have with in single namespace we create a ROLE, if they want across the cluster then we create a CLUSTER ROLE

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c5d7821c-da0d-4796-878d-d1a96a4198c5)

11) We have created the role, Now you have attached this role to users, So to attach we use **ROLE BINDING** 
