# KUBERNETES DEPLOYMENT

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

Deployment
--
1) Can we use pod to deployment conatiner or application, Then what is the use of deployment ?
2) Kubernetes offers you something like **AUTOHEALING** & **AUTOSCALING** it is done by kubernetes deployment
3) 
4) 
