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

**NOTE: THE ABOVE 3 PROBLEMS ARE THEIR IN DOCKER**

# Kubernetes -- Container Orchestration platform


