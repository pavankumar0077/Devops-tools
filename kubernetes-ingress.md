# KUBERNETES INGRESS

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/fe83df56-e833-498a-a3d5-538f9ed50850)

1)Before Ingress

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/307c9bf6-f6c1-4168-8b9b-75469331ce4b)
1) Before ingress or earlier days organization uses ENTERPRISE level load balancing which has a lot of features nginx, F5 load balancer and etc. But after moving from VM to kubernetes all the features are not there.

Deployment -- Service -- load balancing machanism (Round robin) (10 requestes --5 requests for pod 1 and --5 requests for pod 2) -- it is very simple load balancing.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9b4e2639-5ceb-4078-a7ad-16bbebfa63dd)

**1)  Problem one -- No much as before when using VM
2)  Problem two -- When we are using Load balancer Mode
2.1) For 100 services -- we get EXTERNAL IP from cloud provider but they will charge amount for each ip be'coz that ip's are static public load balancer ip adress
2.2) TOO much charge for static ip's**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/fda1d000-279a-4b3a-9b92-d4c651b4f3d4)

PROBLEMS BEFORE INGRESS
--
1) **Enterprise and TLS load balaning capabilites**
  1.1) Sticky based Load balaning
  1.2) TLS based LB
  1.3) Path based LB
  1.4) Host based LB
  1.5) Ration based
Note: All these or more no. of service are not providing in kubernetes

2) Service type -- Load balancer -- cloud provider charges more for each and every load balancer service type (1000 service) -- static public ip address


![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9bd03204-64d3-47ef-b183-12454fb4382c)



![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/92dfe860-6fc4-4ba4-83d5-6e2d5c3e99bc)


1) In kubernetes cluster -- created a pod by yaml file -- api server will notifies **kubelet** -- and kubelet will deploy a pod
2) Service -- **kube proxy** -- update the ip tables
3) Ingress -- their has to be a resource or component or a controller which has to watch for this ingress.
**4) Kubernetes says i an create a ingress but if kubernetes wants to implement logic for all the load balancer that are available like nginx, f5,  Hf, traffic tecnically it is not possible**
**5) So kubernetes come up with architecture that is User will create ingress resouce, Load Balancing companies like nginx, F5, HF traffic they will write their own ingress controllers and they will place these ingress controllers on GITHub, and they will provide the steps to how to install these ingress controllers using HELM charts etc.**
**6) As a User you are creating ingress resource you also deploy ingress controller (It is upto the organization to choose which ingress controller they want to use) Ingress controller is nothing but a Load balancer something it acts as load balancer + api gateway**
**7) With one ingress we can handle 100 + services as well using paths**

SOLUTION IS 
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/4c5dedf0-51f3-4121-87d1-617f7b592570)

1) **Ingress resource and we also need ingress controller**
2) **Without of ingress controller their is not use of how many ingress resources are created in kubernetes cluster**
3) **Ingress controller is nothing but LOAD BALANCER**
4) We need to choose which ingress controller we need like Niginx, F5, HF proxy and etc
5) They will get which type of load balancing we wnt like path based, host based and etc.

Host based load balacning
--
1) aloow users when users are trying to access example.com or example.com/abc
2) Allowing users to access the application when they use example.com (for example)


commands
--
To get ingress
```
kubectl get ingress
```

To get ingress controller
--
```
kubectl get pods -n ingress-nginx
```
or
```
kubectl get pods -A | grep nginx
```
To verify controller is working and identified the ingress resources
--
```
kubectl logs -f ingress-nginx-controller-6cc5ccb977-8g9hs -n ingress-nginx
```
controller - name, and -n name - space

Note: 1) It will go to the nginx load balancer configuration -- that is nginx.conf file -- and it will update so ingress related configuration for the ingress resource that we created.

Note: if we are using ingress in minikube then we need to update hosts in, FOR pord env in aws cloud or others no need to do this.
2) We dont have domain for this example that is also a reason we need to add in hosts.
```
sudo nano /etc/hosts
```
1) Add ingress ip address and host name in the list
2) Get the ip address by using this command ``` kubectl get ingress ```

Now test the application using ingress given host
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/00e9ef44-5ad7-44d0-904e-df21272aad13)


REF LINKS
--
1) https://kubernetes.io/docs/concepts/services-networking/ingress/
2) For ingress controllers -- https://kubernetes.io/docs/concepts/services-networking/ingress-controllers/
3) For minikube nginx controller -- https://kubernetes.io/docs/tasks/access-application-cluster/ingress-minikube/




