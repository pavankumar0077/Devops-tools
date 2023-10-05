# TROUBLESHOOTING COMMON KUBERNETES PROBLEMS

1) KUBERNETES REF LINK : https://kubernetes.io/docs/reference/generated/kubernetes-api/v1.27/
2) KUBERNETES CHEATSHEET : https://kubernetes.io/docs/reference/kubectl/cheatsheet/
3) REF LINK : https://kubernetes.io/docs/tasks/administer-cluster/manage-resources/quota-memory-cpu-namespace/
4) REF LINK : https://www.airplane.dev/blog/category/kubernetes

### KIND IS VERY FAST IN DEVELOPMENT : IT RUNS INSIDE A DOCKER CONTAINER
- MINIKUBE
- KIND
- K8'S

KUBERNETES DEBUGGING & TROUBLESHOOTING
- Image PullBackoff
- ErrlmagePull
- Registry Unavailable
- Invalid ImageName
- CrashLoopBackOff
- KillContainerError

1) Image PullBackoff
  - Invalid Image / Invalid Tag / Invalid Permissions.

How to find this ?
-- Ex: ``` kubectl create deployment nginx --image=nginx
deployment.apps/nginx created ``` 
- Here we are creating a deployment for nginx, It will pull the docker image with name nginx, So it is exits in dockerhub it will pull
- To know that our container successfully pulled or not use ``` kubectl describe pod <pod-name> ```
- In the button we will find this ![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/3d2ab033-58c1-4d3a-81af-6e76cb41ed3e)
``` nginx-77b4fdf86c-5kzwr   1/1     Running   0          4m11s ```
- I have changed the nginx to some other name like nginx1 which really does not exits in dockerhub, We can get IMAGE PULLBACKOFF error ```  kubectl edit deploy <deployment-name> ```
- Now we will error like ``` nginx-64c496d487-mg2h5   0/1     ImagePullBackOff   0          86s ```

 2) ![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/82955658-d37e-4b12-bf7b-502eab7f7512)
 3) From the above example, What if everything is correct, STILL MY APPLICATON IS NOT WORKING
  - In general KUBERNETES ADMIN, He will allocate resource quota for each and every namespace.
  - Let say we have your KUBERNETES CLUSTER and that cluster should be used by 5 TEAMS. Now the Kubernetes Admin will allocate the resouces dependening up on the requirement
  - Let say Team DEV-APP required more resources and Team DEV-CHECK needs less resources admin will assigns resources for us
  - Logical separation is depends on namespace

    ```
    apiVersion: v1
      kind: ResourceQuota
      metadata:
        name: mem-cpu-demo
      spec:
        hard:
          requests.cpu: "1"
          requests.memory: 1Gi
          limits.cpu: "2"
          limits.memory: 2Gi
      ```

  - Here are can allocating the resources for namespace
  - Here minimum cpu is 1 and maximum is 2
  - If user wants to create 4 pods so they have to look into resource quota check for requests and limits and they have configure they pods according to quota
  - NOW CREATE DEPLOY IN new namespace that has ResourceQuota mentioned above
  - ``` kubectl create deploy nginx --image=nginx -n payments ``` (payments namespace)
  - ``` kubectl get deploy -n payments ``` Now you will see that deploy is not up and running
  - To debug we have to use ``` kubectl describe deploy nginx -n payments ```
  - ![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/83a5fa8e-50c1-4d92-9aa9-82081150eab9)

### WHY IT FAILED TO CREATE
- KUBECTL EVENTS
- Whenever you have created anything in kubernetes, it creates events for us
- Our pod has to be created but not getting created for some reasons we have to look for the events
- To check ``` kubectl describe ``` and ``` kubectl logs ```
- ``` kubectl get events --sortby=.metadata.creationTimestamp ```
- You will find the info nodes, pods everything realted to k8s

3) **CrashLoopBackOff**
4) ```
    Liveness Probe Failure
    Application Failed to start for any reason
    The Tricky Part:
    How to fix this ?
    Challenges ?
   ```
- Our image is pulled successfully, no issues with resource quota as well
- After container is pulled and after container is created, During the RUNTIME you have noticed that your pod is not running and your container it got created by immediately it ran into error state
- and it ran into CRASH LOOP BACK OFF
- This error occurs when runtime configuration is not working, Let say you have python application it is working that applicaiton is writing to a file or a folder which does not exists
- Or that folder or file or user does not have permissions too.

LIVENESS PROBE : IN PRODUCTION Senearios, You will define your POD with both LIVENESS PROBE and READYNESS PROBE 
- This liveness probe basically use to understand that your application is live
- readyness probe is used to understand that your application is ready to accept the traffic

## ==================================================================
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/f2d29db9-aa9d-4caa-85cb-2edd69b0f2a3)

## OOMKilled (Out of memory killed)

- Ex: We have kubernets cluster with ONE NODE AND ONE MASTER architecture on this node we have setuped a kuberntes POD
- Simiarly to you all the other who has the access to namespace they started to create more and more NODES
- Here NODE is nothing but EC2 or VM
- Because people started to create more and more you RUN INTO OUT OF MEMORY, Node is not allowing you to create any more resources
- Or application trying to consumer more resources from the NODE and it is not getting enough resources

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/b4969698-1fc8-482e-bdc8-cbadc69e2ad7)

SENARIO 1
==
- In Generally kubernetes, There are 2 different types of OOM Errors:
- 1) OOMKILLED : Limit Overcommit
  

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/a62fe5b1-3ed7-4b98-973d-7c059934e22a)

- Inside the application there will a PID to find PID, directly login into the container or the pod and use the command like ``` ps -ef ```
- Using the PID can we take the THREAD DUMP
- THREAD DUMP --- Take the thread dump using kill - 3 command or JSTACK tool
- Take the kill - 3 ouuutpt and send to developer

SENARIO 2
==
2) OOMKILLED : Container Limit Reached
- cLUSTER HAS LOT OF space, Dev's started to deploy more and more applications
- ``` kubectl get events ``` to find out
- ``` https://www.airplane.dev/blog/category/kubernetes``` tool to fix this issues 
   
