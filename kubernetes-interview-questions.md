# KUBERNETES INTERVIEW QUESTIONS

1) Difference b/w docker and kubernetes ?
 - Docker is container platform, Kubernetes is the container orchestration platform
 - Kubernetes environment that offers capabilities like Auto headling Auto saacling, Clustering and Enterprise level
         support like Load balancing, Custom resources.

3) What are the main components of Kubernetes architecture?
- On a broad level, you can divide the kubernetes components in two parts
- Control Plane (API SERVER, SCHEDULER, Controller Manager, C-CM, ETCD)
- Data Plane (Kubelet, Kube-proxy, Container Runtime, kube-dns)

3) What are the main differences between the Docker Swarm and Kubernetes?
- Kubernetes is better suited for large organisations as it offers more scalability, networking capabilities like policies and huge third party
ecosystem support.

4) What is the difference between Docker container and a Kubernetes pod ?
- A pod in kubernetes is a runtime specification of a container in docker. A pod provides more declarative way of defining
using YAML and you can run more than one container in a pod.

5) What is a namespace in Kubernetes ?
- In Kubernetes namespace is a logical isolation of resources, network policies, rbac and everything. For
example, there are two projects using same k8s cluster. One project can use
ns1 and other project can use ns2 without any overlap and authentication problems.

6) What is the role of kube proxy?
- Kube-proxy works by maintaining a set of network rules on each node in the cluster, which are updated dynamically as services
are added or removed. When a client sends a request to a service, the request is intercepted by kube-proxy on the node where it was received. Kube-proxy then
looks up the destination endpoint for the service and routes the request accordingly.

- Kube-proxy is an essential component of a Kubernetes cluster, as it ensures that services can communicate with each other.

7) What are the different types of services withiin Kubernetes?
- There are three different types of services that a user can create
   - Cluster ip mode
   - Node Port Mode
   - Load Balancer Mode

8) What is the difference between NodePort and LoadBalancer type service ?
 - When a service is created a NodePort type, The kube-proxy
updates the IPTables with Node IP address and port that is
chosen in the service configuration to access the pods.

 - Where as if you create a Service as type LoadBalancer, the
cloud control manager creates a external load balancer IP
using the underlying cloud provider logic in the C-CM.
Users can access services using the external IP

10) What is the role of Kubelet ?
 - Kubelet manages the containers that are
scheduled to run on that node. It ensures that
the containers are running and healthy, and that
the resources they need are available.

- Kubelet communicates with the Kubernetes API
server to get information about the containers
that should be running on the node, and then
starts and stops the containers as needed to
maintain the desired state. It also monitors the
containers to ensure that they are running
correctly, and restarts them if necessary.


10) Day to Day activities on Kubernetes
- As part of the devops engineer role we manager kubernetes cluster for our organization and we also ensure that
the applications that are deployed on kubernetes cluster and there are no issues with the application
- We can setup monitoring on kubernetes cluster, we ensure that whenever we have bugs on the kubernets cluster for example the dev or not able to trobleshoot some issues with respective pods with respective services not able to route the traffic into the kubernetes cluster
- In such cases as Subject matter expert we come into picture we solve the issues, But apart from that we also do
lot of maintance activities for example: we have kuberneets cluster with 3 master nodes 10 worker nodes So we have to do some continous maintaince acitvities on these worker nodes probably upgrading the versions of the worker nodes or installing some default packages, ensuring the worker nodes are security vulnerblilites. Anyone in the organization have any issue they will craete a JIRA tickets we solve that issues 

11) What are some challenges with Prometheus ?
- Despite of being very good at K8 monitoring, prometheus still have some issues:
Prometheus High AvaliablityHow do you handle your kubernetes cluster security? support.
● No downsampling is available for collected metrics over the period of time.
● No support for object storage for long term metric retention.
- You may run multiple instances of prometheus HA but grafana can use only of
them as a datasource. You may put load balancer in front of multiple prometheus
instances, use sticky sessions and failover if one of the prometheus instance dies.
This make things complicated. Thanos is another project which solve these
challenges.
- Ref link : https://thanos.io/v0.10/thanos/getting-started.md/

12) How do you handle your kubernetes cluster security?
- There are many things that you can do, some of them are:
By default, POD can communicate with any other POD, we can setup network
policies to limit this communication between the PODs.
RBAC (Role based access control)
Use namespaces for multi tenancy
● Set the admission control policies to avoid running the privileged containers.
Turn on audit logging.

13) How two containers running in a single POD have single IP
address?
- Kubernetes makes use of Pause containers for sharing networking.
- Kubernetes implements this by creating a special container for each pod whose
only purpose is to provide a network interface for the other containers. These is
one pause container which is responsible for namespace sharing in the POD.
Generally, people ignore the existence of this pause container but actually this
container is the heart of network and other functionalities of POD. It provides a
single virtual interface which is used by all containers running in a POD.

14) What is Service Mesh and why do we need it?
- A service mesh ensures that communication among containerized and often
ephemeral application infrastructure services is fast, reliable, and secure. The
mesh provides critical capabilities including service discovery, load balancing,
encryption, observability, traceability, authentication and authorization, and
support for the circuit breaker pattern.

15) What is init container and why do we need it ?
- Init Containers are the containers that should run and complete before the startup of the
main container in the pod. It provides a separate lifecycle for the initialization so that it
enables separation of concerns in the applications.

- All the init Containers will be executed sequentially and if there is an error in the Init
container the pod will be restarted which means all the Init containers are executed
again. So, it's better to design your Init container as simple, quick, and Idempotent.

- source: https://medium.com/bb-tutorials-and-thoughts/kubernetes-interview-questions-part-1-eb8
8a9df785f

16) What is a Pod Disruption Budget ?
- A PDB specifies the number of replicas that an application can tolerate having, relative to how
many it is intended to have. For example, a Deployment which has a .spec.replicas: 5 is
supposed to have 5 pods at any given time. If its PDB allows for there to be 4 at a time, then the
Eviction API will allow voluntary disruption of one (but not two) pods at a time.

17) What's the Difference Between a Voluntary and Involuntary Disruption?
- It is important to remember that PDBs only apply to voluntary pod disruptions/evictions, where
users and administrators temporarily evict pods for specific cluster actions. Users may apply
other solutions for involuntary pod disruptions, such as replicating applications and spreading
them across zones.

18) What is a custom controller? Did you build one and How to build
one ?

19) What is a SideCar Container and when to use one ?
- Whenever you want to extend the functionality of the existing single container pod
without touching the existing one.
- Whenever you want to enhance the functionality of the existing single container pod
without touching the existing one.
- You can use this pattern to synchronize the main container code with the git server pull.
- You can use this pattern for sending log events to the external server.
- You can use this pattern for network-related tasks.
- source: https://medium.com/bb-tutorials-and-thoughts/kubernetes-interview-questions-part-1-eb8
8a9df785f

20) What is a Pod Security Policy ?
- Instead of this you can use:
	•  Pod Security Admission
	 Pod security restrictions applied at the Namespace level when pods are created.
	•  A 3rd party admission plugin, that you deploy and configure yourself.
