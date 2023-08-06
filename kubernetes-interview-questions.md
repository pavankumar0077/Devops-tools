# KUBERNETES INTERVIEW QUESTIONS

1) Difference b/w docker and kubernetes ?
A) 1.1) Docker is container platform, Kubernetes is the container orchestration platform
   1.2) Kubernetes environment that offers capabilities like Auto headling Auto saacling, Clustering and Enterprise level
         support like Load balancing, Custom resources.

2) What are the main components of Kubernetes architecture?
A) On a broad level, you can divide the kubernetes components in two parts
1. Control Plane (API SERVER, SCHEDULER, Controller Manager, C-CM, ETCD)
2. Data Plane (Kubelet, Kube-proxy, Container Runtime, kube-dns)

3) What are the main differences between the Docker Swarm and Kubernetes?
A) Kubernetes is better suited for large organisations as it offers more scalability, networking capabilities like policies and huge third party
ecosystem support.

4) What is the difference between Docker container and a Kubernetes pod ?
A) A pod in kubernetes is a runtime specification of a container in docker. A pod provides more declarative way of defining
using YAML and you can run more than one container in a pod.

5) What is a namespace in Kubernetes ?
A) In Kubernetes namespace is a logical isolation of resources, network policies, rbac and everything. For
example, there are two projects using same k8s cluster. One project can use
ns1 and other project can use ns2 without any overlap and authentication problems.

6) What is the role of kube proxy?
A) 6.1) Kube-proxy works by maintaining a set of network rules on each node in the cluster, which are updated dynamically as services
are added or removed. When a client sends a request to a service, the request is intercepted by kube-proxy on the node where it was received. Kube-proxy then
looks up the destination endpoint for the service and routes the request accordingly.

6.2) Kube-proxy is an essential component of a Kubernetes cluster, as it ensures that services can communicate with each other.

7) What are the different types of services withiin Kubernetes?
A) There are three different types of services that a user can create
   7.1) Cluster ip mode
   7.2) Node Port Mode
   7.3) Load Balancer Mode

8) What is the difference between NodePort and LoadBalancer type service ?
A) 8.1) When a service is created a NodePort type, The kube-proxy
updates the IPTables with Node IP address and port that is
chosen in the service configuration to access the pods.

    8.2) Where as if you create a Service as type LoadBalancer, the
cloud control manager creates a external load balancer IP
using the underlying cloud provider logic in the C-CM.
Users can access services using the external IP

9) What is the role of Kubelet >
A) 9.1) Kubelet manages the containers that are
scheduled to run on that node. It ensures that
the containers are running and healthy, and that
the resources they need are available.

  9.2) Kubelet communicates with the Kubernetes API
server to get information about the containers
that should be running on the node, and then
starts and stops the containers as needed to
maintain the desired state. It also monitors the
containers to ensure that they are running
correctly, and restarts them if necessary.


10) 

   
