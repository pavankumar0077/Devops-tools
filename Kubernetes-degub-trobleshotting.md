# TROUBLESHOOTING COMMON KUBERNETES PROBLEMS

KUBERNETES REF LINK : https://kubernetes.io/docs/reference/generated/kubernetes-api/v1.27/
KUBERNETES CHEATSHEET : https://kubernetes.io/docs/reference/kubectl/cheatsheet/

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
   
