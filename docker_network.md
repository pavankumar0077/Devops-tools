![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/e34381c4-644d-44c2-a212-65d20f038594)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/2efeb14e-57d5-4107-a83d-86848f69f71b)

IMP NOTES
--
SENARIO 1
--

1) Here we have 2 containers and 1 is front end container and 2nd is backend container and this 2 containers should communicate with each other.
2) Frontend -- should talk to backend.
3) There should be a networking way to talk to each other.
4) Any container will definitly talk to the host be'coz containers are package or bundle which don't
  have complete operating systems.
Subnet : Basically a networking group


SENARIO 2
--
ISOLATION
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/6da02f0c-9163-4e38-be5e-c8dee6769a23)


1) 2 Containers 1 is Login and other payment, which are completely isolated that means, that they are not is same
   network, they don't talk to each other.

what does a docker container will talk to the system or host

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/258c3192-e14d-4ba3-8f4f-efc77a7a72e3)

--
1) By default we have eth0 network Ex: 192.168.138.156, It will be created by default by any resources that you are creating that as container or VM.
2) Docker conatiner runs of 172.17.0.2 eth0
3) If we try to ping from container 172.17.0.2 to 192.168.138.156 host machine. The ping will not work we will get network error.
4) # To the solve docker created as virtual network called eth with basically docker 0
6) WIthout this virtual network conatiner can not talk to the host. And this is called Bridge network
7) # Default network in docker is bridge networking. This is virtual eth which is called docker 0
8) If we try to docker this bridge network then the container will not talk to host


Docker networks
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/cd37b2cf-345f-4b35-ab70-f8db81197016)


1) Bridge network
2) Host networking --- Containers will directly use the host. In this case docker will directly bind ip address of the host not exactly ip address eth0 of the host, when we are creating container.
-- Host has 192.168.138.4 and conatiner as 192.168.138.6, both of them are in same subnet. Bydefault we
  y ou try to ping the conatiner to host, it is possible.
-- Whoever have the access to host can also have access to container.
3) Overlay networking -- Mostly used in k8s or docker swarm


Isolated containers
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/1d8ad481-b38d-4cc3-a6da-ec3d6299f542)

1) Container 1 is login container and container 2 is the finance container. The finance container is completely isolated or as much as secure as compare with login container.
2) But if we use the default network. there is only one eth0 docker 0 the container 2 finance conatiner
will also use the same network, and both of them are using the same virutal network to talk to the host.
3) This is the problem and it is not secure.
4) # If we are using Out of the box bridge networking all of the container can ping or one container can ping other conatiner can talk to the host using veth0. This is also not secure.

THE ABOVE PROBLEM WILL BE SOLVED BY BRIDGE NETWORKING (Isolated containers)
--
# Docker allow us to create own custom bridge network

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/e1ac3b76-3e6f-4738-8a71-b4762762bd6d)






   
