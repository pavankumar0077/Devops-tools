# CUSTOMER RESOURCE DEFINATION (CRD)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c4bb77d7-98b8-4821-96c3-7a434e4b1626)


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

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/6fe75b0c-63c1-40a3-93ab-034edca83ae4)

1.1) Kubernets will have template which has all the fields related to deployment.yaml file kubernetes throws
error if we read like xyz something which is not there, Be'coz kubernetes have a defination with it that's why
it is able to throw error.
1.2) A CRD is a yaml file which is used to introduce a new type of API to kubernetes and that will have all the
fields a user can submit in the custom resource


