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

Installation
--
**Kubectl** -- https://kubernetes.io/docs/tasks/tools/
**minikube** -- https://minikube.sigs.k8s.io/docs/start/#:~:text=Download%20and%20run%20the%20installer%20for%20the%20latest%20release.&text=Add%20the%20minikube.exe%20binary,to%20run%20PowerShell%20as%20Administrator.&text=If%20you%20used%20a%20terminal,reopen%20it%20before%20running%20minikube.

1) Minikube is a CLI tool that helps to create kubernetes cluster

Kubernetes cluster will be started (Linux)
```
minikube start
```
Note: In windows or mac it will create a VM first on top of it will create a single node kubernetes cluster, In production we use master node and worker nodes based on requirements no. of workers nodes

Create a pod
--
Ref link : https://kubernetes.io/docs/concepts/workloads/pods/
1) A pod is a specific to run a docker

Example
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/130430fa-726d-45ce-8587-d7fb714f765e)

Docker equlivant commmand kubernets 

Step 1
--
Create pod.yaml file 
```
..
.....
.......
```
step 2 
--
Create pod 
```
kubectl create -f pod.yml
```
To get all pods
```
kubectl get pods
```
to get entire details of pod
```
kubectl get pods -o wide
```
To login to kubernetes cluster
```
minikube ssh
```
Note: In real we use master or worker node ip address and we will ssh it

To check pod is running or not

curl <Ip-pod>

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/a92135e3-e1ca-40f9-9c3e-6ca5fb294db1)


NOTE: REF LINK FOR KUBERNETES CHEAT SHEET -- https://kubernetes.io/docs/reference/kubectl/cheatsheet/

To delete pods
```
kubectl delete pod nginx <pod-name>
```
HOW TO GET AUTOSCALING AND AUTOHEALING 
--
1) We have a wrapper called deployments in kubernetes
2) We have to use deployments in kubernetes to get the features of autoscaling and autohealing

Note: In real we don't deploy pods we use deployments, stateful sets, deamon sets, Way to deploy apps

Q) How do you debug pods, or debug applications issues in kubernetes
How to verify the appn's
--
```
kubectl describe pod <pod-name>
kubectl describe pod nginx
```
To check lods
```
kubectl logs <pod-name>
kubectl logs nginx
```
To get all the deployments, pods, psv, svc and etc use 
```
kubectl get all
```







