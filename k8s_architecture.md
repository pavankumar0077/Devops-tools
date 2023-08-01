# K8s Architecture

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/90b29d62-6707-4a1d-bd20-def330b56634)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ab4383e7-e451-4a8b-9e0c-74f79c3378b5)

Ex: Docker image -- Docker run -- Docker container is running 
Without container runtime, our container never run , So we have container runtime in docker it is called
**DOCKERSHIM**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/5a7f3d73-ae85-4a10-a4bb-e8877435013e)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/04d2064b-3bdd-4afa-95fd-4189a42808d2)

# WORKER NODE:

Ex: One master one worker node in Kubernetes we don't send request directing to the worker, but the request 
goes through master node it is called the control panel.
1) KUBELET : When we deploy a pod on worker node, we have a component in kubernetes that is called kubelet it will responsible for running our pod and maintaining our pod, and inform the kubernetes lor component ike if pod is not running and other issues.
   
2) CONTAINER RUNTIME : Insert the pod we have container, even to run that pod we need container run time, **In kubernetes docker is not mandatory**, we can use conatinerd, dockershim, cri-o these are all competition to dockershim, **Docker has only one support that is dockershim** Where as Kubernetes can support conatinerd, crio or any that conatiner run time which implements Kubernetes conatiner interface.

3) KUBE PROXY :  default networking in docker is docker0 bridge network, In **kubernetes we have kube proxy as a networking** every pod that we are creating it has to be allocated with the ip address and it has to be provided with the load balancing capability, kube proxy also provides load balancing.

 
