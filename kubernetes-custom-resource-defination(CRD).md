# CUSTOMER RESOURCE DEFINATION (CRD)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/cffd37f5-7337-4511-9898-cf838943d4dc)


1) CRD
2) CR
3) Custom Controller

**In kubernetes cluster by default there are some resources that comes out of the box like
Deployment, Service, Pod, Config-map, Secrects and etc which comes with kuberenetes**

**If you want to extend API of kubernetes or you want to introduce a new resource in kubernetes, Like why you
want to introduce new resource in kubernetes if you feel the functionality that you inside the kubernetes
is not supported by any of the available or by-default resources. Example Kubernetes does not support
advance security futures like kube hunter, kube beanch and etc**

NOTE: CNCF is all about custom controllers and tools
--

```
ISTID --- Service mesh 
ArgoCD -- GitOps
KeyClock -- Oauth
..
..
```
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/0a23e9b4-1dd1-4a95-adce-0a40d34aee5b)

# KUBERNETES ALLOWS US TO EXTEND THE API OR CAPABALITY TO THE KUBERNETES LIKE ADDING NEW RESOURCES

To Extend we need 3 resources that are
--
1) CRD
2) CR
3) Custom Controller

1) **CUSTOM RESOURCE DEFINATION** : Defining a new type of API to kubernetes
We use custom resource defination it is yaml file in the yaml we will define things like what a user can create
for example if we are user and we are creating deployment.yaml file in our deploy.yaml file we mention few things
like api, specs, kind template, pod, etc how kubernetes understands that this created deployment.yaml file
is current of not.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/e7d09cb3-2a31-4e91-a5e8-dac9c6457cc7)

```
1.1) Kubernets will have template which has all the fields related to deployment.yaml file kubernetes throws
error if we read like xyz something which is not there, Be'coz kubernetes have a defination with it that's why
it is able to throw error.

1.2) A CRD is a yaml file which is used to introduce a new type of API to kubernetes and that will have all the
fields a user can submit in the custom resource

```

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/64dfe6ef-9e1e-402a-85c0-b00f655a8b85)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/186aa451-151f-414e-ab74-00304f4081e8)

```

1.3) User submited a CR and validated against a CRD, CR is created under kubernetes cluster, In kubernetes you have deployment controller which will take care of replica-set and rs controller will create pod. Kubernetes controller is doing all these things.
1.4) Similarly here we need custom controller for CR, Custom Kubernetes controller which is already deployed in kubernetes cluster 
1.5) Kubernetes cluster -- Step1: If organization wants to use istio or any other CR, They will deploy CRD --> They will find istio docs they deploy using manifest.yaml or Helm or Operators. Devops engineers deploy the CRD.
1.6) Now we have developer or User -- He wants to use the capabilites of istio inside the k8s cluster. He will create a Custom - Resource --> What is thus CR lets say we have namespace called Pavan inside the Pavan namespace he will create a ISTIO virutal service CR, Before it getting created the API server will intercept the request and they will try to validate against the Virtual service CRD if the request is correct then the request will pass through if not the request will fail.
1.7) Here the the VS CR is not being watched by no-one, So here we need a Custom Controller 
1.8) Custom Controller - deployed using Helm or manifest or operators, He can created across the cluster and for specific namesapce based features the controller supporting.
1.9) Now controller will perform the required action, In this case the required action is ISTIO or service mesh mutual DLS or east-west traffic, horizontal traffic, So this ISIO controller which we deployed will read the CR and perform the actions

```

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/d6fbbb27-db24-49be-9a95-83e904f8f90a)

1.10) CRD, Custom controller, specific to namespace CR

How one can write a custom controller
--
1) Ever popular way to read CC is using Golang or python or java. But Golang is popular and even community recommends it be'coz kubernetes application is written on Golang
2) One of the popular Kubernets API is client-go (We have client-python & client-java as well)
3) This client-go will allows us to interact with kubernets api inside the kubernets API server we have a
component called client-go this client-go will allows us to talk to the kubernets api.
4) How to write CC: We use go-lang we have watchers and listeners, By default client-go will set up watchers like we have deployment watcher, service watcher like if we perform update,delete and create their is inbuilt watchers that kubernets are created for this resources whenever we performs any action kubernets will come to know.
5) For Custom - Controller we have a write a new watchers (We can use Kubernets controller runtime) it a go-lang based kubernetes package using thsi we can setup watchers
   
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/51bc0ddd-a0cd-40a9-9642-9191cc99f5fc)
   
7) ISTIO people set up watchers for virtual service so any action create,update,delete there are watchers they will notify client-go in client-go we have package called reflector using this reflector whenever you understand a new virtual service is created you can put that in FIFO (First in first out) queue and will put in the worker queue and we will start reading each of the element or objects form the queue and wathcers will identify and update in the worker queue and we start processing each and every resource
8) Now it will start creating required functionality on the kubernetes in this case it will start the creating a virtual service configuration on kubernetes cluster.
9) We can use operator SDK as well

Resources for CRD
--
1) https://github.com/istio/istio/tree/master
2) https://www.cncf.io/
3) https://github.com/kubernetes/sample-controller
4) https://istio.io/latest/docs/setup/install/helm/



