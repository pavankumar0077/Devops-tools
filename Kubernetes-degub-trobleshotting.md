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

 2) 
