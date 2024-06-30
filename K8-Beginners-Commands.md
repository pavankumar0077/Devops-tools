# SOME OF BASIC USEFULE COMMANDS

```
Cluster Management Commands

a) kubectl cluster-info
Purpose: Display cluster information
Usage: kubectl cluster-info
When to use: To check if your cluster is running and get the addresses of the master and services.
b) kubectl version
Purpose: Show the Kubernetes version running on the client and server
Usage: kubectl version
When to use: To verify the version of Kubernetes you're running, which is useful for troubleshooting and ensuring compatibility.
c) kubectl config view
Purpose: Show the kubeconfig settings
Usage: kubectl config view
When to use: To see your current cluster configuration, including contexts and clusters.
d) kubectl config use-context [context-name]
Purpose: Switch to a different context
Usage: kubectl config use-context my-cluster
When to use: When working with multiple clusters or namespaces, use this to switch between them.

Resource Creation and Management

a) kubectl create
Purpose: Create a resource from a file or stdin
Usage: kubectl create -f [filename]
When to use: When you want to create a new resource using a YAML or JSON file.
b) kubectl apply
Purpose: Apply a configuration to a resource by file name or stdin
Usage: kubectl apply -f [filename]
When to use: To create or update resources. This is often preferred over 'create' as it's idempotent.
c) kubectl run
Purpose: Run a particular image on the cluster
Usage: kubectl run [name] --image=[image-name]
When to use: For quick creation of a deployment with a single container.
d) kubectl expose
Purpose: Expose a resource as a new Kubernetes service
Usage: kubectl expose deployment [name] --port=80 --type=LoadBalancer
When to use: When you need to make a deployment accessible within or outside the cluster.

Viewing and Finding Resources

a) kubectl get
Purpose: Display one or many resources
Usage: kubectl get [resource]
Examples:

kubectl get pods
kubectl get services
kubectl get deployments
When to use: To list resources and their basic information. This is one of the most frequently used commands.

b) kubectl describe
Purpose: Show detailed information about a resource
Usage: kubectl describe [resource] [name]
Example: kubectl describe pod my-pod
When to use: When you need more detailed information about a specific resource, including events.
c) kubectl logs
Purpose: Print the logs for a container in a pod
Usage: kubectl logs [pod-name]
When to use: For debugging and monitoring your applications running in pods.

Updating and Patching Resources

a) kubectl edit
Purpose: Edit a resource on the server
Usage: kubectl edit [resource] [name]
Example: kubectl edit deployment my-deployment
When to use: For making quick changes to resources directly on the cluster.
b) kubectl patch
Purpose: Update field(s) of a resource using strategic merge patch
Usage: kubectl patch [resource] [name] -p [patch]
Example: kubectl patch deployment my-deployment -p '{"spec": {"replicas": 3}}'
When to use: To make small, specific changes to resources without modifying the entire object.
c) kubectl set
Purpose: Set specific features on objects
Usage: kubectl set [feature] [resource] [name] [flags]
Example: kubectl set image deployment/my-app container-name=new-image:tag
When to use: To update specific fields of resources, like container images or environment variables.

Scaling Resources

a) kubectl scale
Purpose: Set a new size for a deployment, replica set, or replication controller
Usage: kubectl scale [resource] [name] --replicas=[count]
Example: kubectl scale deployment my-deployment --replicas=5
When to use: When you need to quickly scale the number of pods in a deployment or replica set.

Deleting Resources

a) kubectl delete
Purpose: Delete resources by file names, stdin, resources and names, or by resources and label selector
Usage: kubectl delete [resource] [name]
Example: kubectl delete pod my-pod
When to use: To remove resources from your cluster. Use with caution!

Interacting with Running Pods

a) kubectl exec
Purpose: Execute a command in a container
Usage: kubectl exec -it [pod-name] -- [command]
Example: kubectl exec -it my-pod -- /bin/bash
When to use: When you need to run commands inside a running container, often for debugging.
b) kubectl cp
Purpose: Copy files and directories to and from containers
Usage: kubectl cp [pod-name]:[src-path] [dest-path]
Example: kubectl cp my-pod:/var/log/app.log ./app.log
When to use: To retrieve files from or send files to a running container.

Cluster Management

a) kubectl cordon
Purpose: Mark node as unschedulable
Usage: kubectl cordon [node-name]
When to use: Before performing maintenance on a node, to prevent new pods from being scheduled onto it.
b) kubectl drain
Purpose: Drain node in preparation for maintenance
Usage: kubectl drain [node-name]
When to use: To safely evict all pods from a node before you perform maintenance on the node.
c) kubectl taint
Purpose: Update the taints on one or more nodes
Usage: kubectl taint nodes [node-name] [key]=[value]:[effect]
When to use: To repel certain pods from specific nodes based on taints and tolerations.

Troubleshooting and Debugging

a) kubectl explain
Purpose: Get documentation for various resources
Usage: kubectl explain [resource]
Example: kubectl explain pods
When to use: When you need to understand the structure of a Kubernetes resource and its fields.
b) kubectl port-forward
Purpose: Forward one or more local ports to a pod
Usage: kubectl port-forward [pod-name] [local-port]:[pod-port]
Example: kubectl port-forward my-pod 8080:80
When to use: For debugging or accessing applications running in pods directly from your local machine.
c) kubectl top
Purpose: Display resource (CPU/memory) usage
Usage: kubectl top [resource-type]
Example: kubectl top pods
When to use: To monitor resource usage of pods or nodes in your cluster.
These commands form the core of interacting with a Kubernetes cluster. As you work more with Kubernetes, you'll find yourself using these commands frequently.
Remember, you can always use kubectl [command] --help to get more information about any specific command.

```
