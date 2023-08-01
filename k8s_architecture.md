# K8s Architecture

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/90b29d62-6707-4a1d-bd20-def330b56634)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ab4383e7-e451-4a8b-9e0c-74f79c3378b5)

Ex: Docker image -- Docker run -- Docker container is running 
Without container runtime, our container never run , So we have container runtime in docker it is called
**DOCKERSHIM**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/5a7f3d73-ae85-4a10-a4bb-e8877435013e)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/04d2064b-3bdd-4afa-95fd-4189a42808d2)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0032cb2e-ad38-4c11-81b6-2b25f57de2c2)


# WORKER NODE:
DATA PLANE:

Ex: One master one worker node in Kubernetes we don't send request directing to the worker, but the request 
goes through master node it is called the control panel.
1) KUBELET : When we deploy a pod on worker node, we have a component in kubernetes that is called kubelet it will responsible for running our pod and maintaining our pod, and inform the kubernetes lor component ike if pod is not running and other issues.
   
2) CONTAINER RUNTIME : Insert the pod we have container, even to run that pod we need container run time, **In kubernetes docker is not mandatory**, we can use conatinerd, dockershim, cri-o these are all competition to dockershim, **Docker has only one support that is dockershim** Where as Kubernetes can support conatinerd, crio or any that conatiner run time which implements Kubernetes conatiner interface.

3) KUBE PROXY :  default networking in docker is docker0 bridge network, In **kubernetes we have kube proxy as a networking** every pod that we are creating it has to be allocated with the ip address and it has to be provided with the load balancing capability, kube proxy also provides load balancing.

# MASTER NODE:

CONTROL Plane : If pod is created then who will decide that the pod should created in node 1 or 2 or 3 .., their can muliple instructions like this and their should a  heart or core component to deal with this kind of instructions, Takes all the incomming requests like in future if we need to implement some identity related SSO or security related stuff their should a core component to do, **That is called API SERVER**
It is present in master or control panel of kubernetes 

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0aeb30bb-e809-40b3-b991-dec71fa8e5c0)


**API SERVER** -- It is a component basically exposed kubernetes, kubernetes has to expose to the external
world all of these thinds are basically internal to the kubernetes data panel or worker nodes but heart of the kubernetes is kubernetes **API SERVER** which basically takes all the requests form external world

EX: User is trying to create the POD, he tries to access the API server and from the api server kubernetes
decides that node 1 is free, but to schedule the node 1 we have component in kubernetes that is called as
**SCHEDULER**

Scheduler -- It is basically responsible for scheduling pods or resources in kubernetes who decides the information API SERVER, Who acts on the information that is kube scheduler 

ETCD -- It is basically a key value store the entri kubetenets cluster info is stored as a form of objects key value pairs in etcd 

CONTROLLER MANAGER -- Kubernetes supports auto scaling to support auto scaling it has some components like
automatically detect and done some stuff for that, kubernets have basically some controllers for example: replica set (Maintaining state of kubernetes pod -- it ensure conatiners are running in pods) their should be a component to ensure that these pods are running that component is called as controller manager 

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/a3732a84-ed25-4218-a831-7e02e96c454d)

CLOUD - CONTROL - MANAGER (CCM) -- We can know that kubernetes can be run on mutiple clouds like EKS, AKS 
Their is request to create a load balancer or request to create storage form the user, If we directly send this info to kubernetes it has to understand the underlined cloud provider like in awd or in azure, Kubernetes has to translate the request from user on to api requst  to the cloud provider understages so these machism shoudl be implemented on CCM that means in future their is new cloud implement XXX and you want to run kubernetes on this new cloud, Kubernets saying i can not write logic for this multiple cloud providers i will provide you a component called as CCM it is open source utility for on prremise this component does not required 



 
