
# KUBERNETES SERVICE

Why we need service and what happens when there is no service in kubernetes
--

WHEN THEIR IS NO SERVICE OPTION
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9ab47c58-f7c5-42a1-9955-65decd62a433)

1) We deploy pod as a deployment in kubernetes, deployment will crete a replica-set and RS wiil create a POD
2) We have a requirement of creating 3 replica-sets, Let say their are 10 concurrent users (That means users are using the application at same point of time) If it is one replica it usually go down that'y we use multiple replicas
3) No. of replicas depends up on no. of users trying to access the application and no of connections one particular pod can take
4) If a pod goes down then replica-set will create a pod again auto healing but as pervious pod had different IP and now NEWLY CREATED POD AS NEW IP different from old pod
5) The application come up but IP ADDRESS of the application is changed.
6) This application IP should be shared to other teams to work on in prod

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/2f5fee15-c74e-4508-bb1f-90d393aa6d39)

WHEN SERVICE IS THERE
--
# LOAD BALANCING

1) When a pod goes down, it will create new pod replica-set controller ensures to do that by using auto-healing concept.
2) But after creating new pod it place of old pod the new pod has new IP ADDRESS, so end user or others can not use the application.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/1c10d754-b708-4118-b1c6-231d034f7b0e)
   
4) SO,  TO SOLVE THIS ISSUE WE USE SERVICE ON TOP OF DEPLOYMENT AND THAT WILL ACT AS **LOAD BALANCER** AND WE GIVE THAT SERVICE **IP ADDRESS** TO ACCESS THE APPLICATION TO END USER OR OTHER TEAMS FOR TESTING AND STUFF.
5) Access by using service names, The service internally uses KUBE PROXY 
6) SERVICE usees Kube proxy it will forward the request

EVEN SERVICE IS THERE WE HAVE ONE ISSUE
--
1) When service-name is given instead of pod IP address that's fine, But service should know the new IP address of the pod
2) If service also follow the same problem of keeping a track of IP address the problem is not solved at all.
3) THis PROBLEM SOLVED  is done by **Service Discovery**


THE ISSUE IS SOLVED BY LABELS & SELECTORS
--

# SERVICE DISCOVERY

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/cda13afb-f21d-443d-9e3e-afa40c86d134)

1) What service does i will not bother about IP address at all it will come up with new process called LABELS AND SELECTORS.
2) labels and selectors for every pod that is getting created, dev's will apply a LABEL, the LABEL will be common for all the PODS
3) THE PROBLEM IS Solved, This is the service discovery machism of kubernetes 
4) Whenever we create deployment, inside the metadata of our deployment we create something called as a LABEL (It is jsut a TAG ) this deployment will create REPLICA-SET it will create PODS and for both the PODS it will have LABEL , Let say one pod gone down so the IP will be changed the replica-set will create new pod which has same LABEL
5) SERVICE offer load balacing, and service will keep track of LABELS instead of IP address, It maintains all the stuff and this process is called **SERVICE DISCOVERY PROCESS.**

# EXPOSE TO EXTERNAL WORLD

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/3e75966f-3d1c-4f5f-8b6d-5066b20007ce)

1) A service can EXPOSE our application, Service can allow our application to access outside the kubernetes cluster
2) SERVICE OF 3 types Cluster ip, Node Port, Load Balancer ( These are the default type)
3) IF we create service by cluster IP -- It still only be access inside the kubernetes cluster, We get two benefies that are discovery and load balancer
4) NodePort mode -- It will allow our application to access inside your Organziation, anybody within your Organization or anybody within your Network, Whoever have the node ip address they can access the application.
5) Load Balanceer -- It is basically our service will expose the application to external world
Ex: on cloud EKS -- we will get Elastic load balancer -- anywhere in the world access using public IP address
NOTE: This load balancer will not work on Minikube only works on Cloud paltforms

ALL the concepts in one example
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9cef75e9-8a6d-46fb-b7b2-2b9388ccfd2c)

1) Kubernetes cluster, created a deployment -- replica-set -- pod all of these things is inside a NODE (Worker node 1) On up of this we have SERVICE

CASE 1
-------
We create this as a CLUSTET IP 
1) This service will be only accessed by the people who has access to this KUBERNETES CLUSTER
2) THERE IS CUSTOMER WHO IS OUTSIDE THE ORGANISATION BOTH ARE NOT IN SAME NETWORK HE DO NOT HAVE ACCESS TO APPLICATIONON

CASE 2
--
We have crated LOAD BALANCER TYPE SERVICE
1) The service that got created it will say that if we assume this cluster in AWS, It will notify aws kubernetes api server will notify aws -- EKS -- service load balancer mode -- Can you give me a elastic load balancer IP address which means a PUBLIC IP ADDRESS. CLOUD CONTROL MANAGER IS DOING THIS IT IS PART of master node
2) Now anyone can access the application using internet

CASE 3
-
NODE PORT mode
1) It can give access to people who has access to WORKER NODE 1, So whoever can access the workder node IP ADDRESS. Let say the worker nodes are EC2 instance ip address, They can access me
2) Whoever has EC2 instance trafiic or VPC traffic they can access the application or pods.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/57d9363a-d2f8-4268-b93e-5eb0acebbe1d)
