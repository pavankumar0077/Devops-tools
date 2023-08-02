# KUBERNETES PODS

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/eb9c1ec7-7f4c-4b36-90c5-a8230001706c)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/d1fcde62-e4f0-4edf-b002-adcc80c834a5)


**POD** : It is a defination for how to run the container. Ex: In docker if we want to run a container "docker run <img-id> port"
In kubernetes we pass the value like port, volume, network etc in yaml file. pod.yaml file (Kubernetes manifest files)

Pod is also exactly like docker, but only difference is in docker we use commands like docker run p conatiner id v .. but here we use yaml files .. apiVersion, spec, kind and etc

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9307fecc-a90b-4384-b1c8-586a617be637)

Note: This can be achieved by docker containers also then why this yaml files and complex stuff 
what you have to run things using kubernetes 
-- Kubernetes is enterpise level platform it want to bring declarative capabilies or it want to build a
standarization 

NOTE: Kubernetes deals everything using yaml files.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/8f05aea1-c81b-4cf2-9e4b-f1c32c55e832)

**Pod** -- Is one or group of containers mmustly only one container but there are few cases like side-car conatiners, init conatienrs is are like supporting conatiners, it supports actual  conatiner. 
Ex: A conatiners wants to read file from other conatiner like config files or user related data,
Instaed of creating 2 different pods we can put both of them in singel pod what pod says is if you one or two conatiners or multiple conatiners inside a single pod kubernetes will ensure that both of the conatiners will have some advantages that's why you put one or group of containers inside a single pod when it is required.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ad1ac20e-c643-40c7-8ef0-b9fc7d227fe6)

Advantages of keeping group of containers in single pod
--
1) Kubernetes will allow you shared networking
2) Shared storage
3) Container a and container b inside a single pod can talk to each other using local host
4) This is rare case like group of containers in single pod, The usually pratice is to create side-car containers or init containers

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/bd75a2c6-69c1-4d89-ba07-b88a690dbcfb)

5) Pods have cluster ip address, kube proxy will generate this ip addresses 

KUBECTL
--
1) kubectl is command line for kubernetes
2) directly interact with kubernetes clusters, kubetes get nodes, get pods and etc commands
