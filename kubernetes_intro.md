# KUBERNETES

# Docker -- Container platform
1) Container are ephemeral in nature (That means -- short life ) die and revive anytime
Ex: For example we have 100 conatiners and suddenly one container is taking more resources ram and space and
other conatiner is not getting resources (It will die or if it not already scheduled conatiner will not get 
started. If their is lack of resouces then container will die bec'z we have one host here.

Problems with docker
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/67009286-43dd-42c3-be21-0a2c6c3b8801)

1)**One Single host** -- Bec'z it is single host the containers which are there it is impacing each another and
if one of the container is impacting other conatiner  there is not way that the conatiner will come up.


![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c3020b88-fb28-4d30-acca-129a52a50bda)

2) **Killed Container** -- Somebody killed your conatiner, Immediately the application that is running inside
the container will be not accessable. (This behaviour is called **_Auto Healing_** Without the user manual
intervention your conatiner should start by itself.)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/8d2e656b-985e-49f5-a9f0-e0a4488fff66)

3) **Auto Scaling** -- You have a host on up of it we have docker and we have some conatiners, For Ex: our host
has 4GB ram and 4Cpus and the conatiner can maximum consume upto 4GB RAM 4GB CPU, Like a shopping application has
more number of hits and user on festival seasons. As soon as the load gets increased
3.1) **Munually** _increase the conatiner count from 1 to 10 times_
3.2) **Automaticlly** _As soon as it gets the load the docker conatiner should understand_
that load is getting increased i have scale up, _But docker does not support both of the things manual increase and autoscaling_
_**So load balacer which is acutally send you the load whether you are doing it maually or automatically, So this
load balancer basically says that instead of 1 container there are 2 or many and it will equally split the load
by this machanism load balancer which supports your autoscaling**
_

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/957cdd8e-d780-414b-bc64-741bc7f4bf1b)

4) **Simple platform** -- Bydefault docker does not support any of the enterpise level application support (Load balancer, firewall, autoscale, auto healing, api gateways -- not supported in docker) by default it will not enterpise level applicaiton support **_Unless if we go to docker swarm and etc to get support_** 

**NOTE: THE ABOVE 3 PROBLEMS ARE THERE IN DOCKER**

_# Kubernetes -- Container Orchestration platform_
**CLUSTER** -- CLuster is a group of nodes 
1) KUBERNETES in general installed as a cluster on **master/node architecture**, Whenever we install kubernetes we just install one master node and we create multiple nodes from master node. One advantage of installing Kubernetes as a cluster is that if a node becomes faulty and affects other applications, Kubernetes can quickly redistribute the pods to other nodes or applications within the cluster. This is because Kubernetes is designed with a multiple node architecture that behaves like a cluster, making it an ideal solution for this type of problem. It is important to note that Kubernetes is naturally a cluster-based system.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/421ee753-5a4b-467c-98f6-720f43dcbfa7)

   
2) Replication controller or replica-set : We have increase replic-sets, For example for our app'n in festival session traffic will increase so the load will be increase, If we increase the
no of replica's then the load will be distributed and shared among the created nodes from the replica-sets.
Kubernetes supports **HPA(Horizontal Pod Autoscale)** -- using this we can directly say that whenever there is a load just keep increasing replica-set pods, If any of the containers receiving a threshold of 80% increase one more container. In this way, Auto-Scaling is solved.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9bc1281b-b0b3-445e-893c-bb92e74af80d)


3) Auto-Healing -- Wehnever their is damage kubernetes should control the damange and fix the damage, Ex: For some reason conatiner is going down, whenver conatiner is gng down or even before the container goes
does kubernetes will start a new conatiner. How kubertes does that it has** API SERVER** understand that one of the conatiner is gng down or whenever it receives a signal call like conatiner is gng down immediately it will rollout the new container

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/fa484061-f176-49b6-b47c-c7514fea5bb8)


4) Entrprise applicaiton support --
_**Note: docker will not be used in the production be'coz it is not enterprise level **_






