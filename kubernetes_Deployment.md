# KUBERNETES DEPLOYMENT

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/5f999854-fa78-4379-a6f7-3c2cfe05682a)

Container 
--
1) Use docker or any other containzeried platforms to create conatiners
2) docker run -it -d <img-name> port ....


Pod
--
1) Kubernetes tells to use YAML files (called manifest files) instead of writing in command line
2) Inside the manifest files we can define conatiner image-name, port, network,  mount, volume and etc
3) It is nothing but a running specification of docker container
4) A pod can be singal or multiplye container
5) We create multiple conatiner be'coz one container is dependent of other container (sidecar container)
6) Use case is service mesh, Both the conatiners have same volume same network localhost
7) Pod is somewhere similar to the container but it is doing nothing just a yaml specification of the container
8) Pod can not do AUTOHEALING & AUTOSCALING

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/82039ea4-7f69-4e8f-a798-761464ce079e)

Deployment
--
1) Can we use pod to deployment conatiner or application, Then what is the use of deployment ?
2) Kubernetes offers you something like **AUTOHEALING** & **AUTOSCALING** it is done by kubernetes deployment
4) Deployment will End of the day do deployment only, Instead of deploying a pod if we deploy a deployment resource, It will again create  intermediate source called replica set then replica set will create something called pod
6) Kubernetes suggests us to do not create pod directly, But create is using a deployment resource -- firstly i  will create a replica-set which is kubernetes controller and it will rollout our pods

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/26b0b445-4e21-4f29-af03-b6df6526a340)

8) Inside the deployment.yaml manifest relica-set count as 2 or 3 based on the requirement but when we given this manifest file their had something in kuberenets that ensure that if have 2 pods, even if user delete on the pods accidently, be'coz in manifest it is 2 it will implement autohealing and make 2 no of pods.
9) The end process it you will create a deployement and it will rollout replica-set and this is create no of pods that we have mentioned in deployment.yaml file, Replica-set ensure to implement the auto-healing capability, It is called **Zero downtime deployment**. Replica-set is called **kubernetes controller**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/95031be7-d399-4c1a-a166-be315a45bd3a)

11) Controllers - They maintain a state, it always ensures that the desired state is present on the acutal cluster both are some or not. We can create custom controllers as well.

To get all the deployments, pods, psv, svc and etc use (All the resouces in particular name space)
```
kubectl get all
```
To get all resources with all the namespaces
```
kubect get all -A
```
Login to remote kubernetes cluster
--
```
ssh -i <>
ssh -i (identity) name or node or ip address of the node
```


Interview questions
--
1) Difference between pods vs container vs deployment
2) depolyment and replica-set

Create a deployment
--
Ref doc : https://kubernetes.io/docs/concepts/workloads/controllers/deployment/#:~:text=A%20Deployment%20manages%20a%20set,state%20at%20a%20controlled%20rate.

To create deployment
--
```
kubectl apply -f deployment.yml
```
OR
```
kubectl create -f deployment.yml
```
NOTE: AS SOON AS WE CREATED DEPLOYMENT WE HAVE DEPLOYMENT AND POD AS WELL BE'COZ OF REPLICAS 
it is done by replica-set controller 

To get the deployment
```
kubectl get deploy
```
To get pods 
```
kubectl get pods
```
To get replica-set
--
```
kubectl get rs
```
To watch pods in live
--
```
kubectl get pos -w
```

NOTE: DEPLOYMENT is an abstraction, that means we don't have to create replica-sets, pods, It says create one resouce called deployment.yaml and i will create the rest of them, It is responsible for auto-healing and zero down time in kubernetes,  deployment will take help of replica-set and replica-set is kubernetes controller which is actually doing it 

Kubernets controller
--
1) It is nothing but a Go language application that kubernetes as written which will ensure that a specific behaviour is implemented, Ex:

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/261f53a3-0190-42b6-9ea9-84b2c5793f1d)
2) we are watch the pod 

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/ef0562b1-da2b-476c-970e-82782e9873ce)
3) deleted pod

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/38eb5416-c535-4074-b66e-04fc25fc7b83)
4) It is again re-creating be'coz of auto-healing , Replica-set controller will do this


In prod env
--
1) We never create pods directly
2) We create deployment and it will created Replica-set and then Pod will be created
