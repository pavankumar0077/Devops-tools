# KUBERNETES - MONITORING


why monitoring is required
--
1) To check all the pods, deployment, api server any other issues

Installation of prometheus
--
**We can install using HELM or OPERATORS**
either use helm or operators

1) In general - Operators offers a lot of advance capabilites like we can do life cycle managment of kubernetes, controllers using ooperators
2) We can configure for automatic upgrades, Ex: if we have any new version of prometheus operators have capability to upgrade it automatically

Follow these repo for installation - ``` https://github.com/pavankumar0077/prometheus-Grafana-Zero-to-Hero/blob/main/Installation/Prometheus/helm.md ```

# kube-state-metrics 
1) Kubernetes api server it exposes few metrices of the kubernetes, It gives the information about the api server, default installation of kubernetes clusters
2) As we are monitoring kubernetes cluster we might need more information about all the resources like pods, deployments, services in kubernetes cluster
3) If you want to know the replica count is matching the expected replica count of all the deployments of the kubernets cluster
4) kube-state-metrics -- We can create service for kube-state-metrics and we can use this k-s-m, So when we call k-s-m on the metrics endpoint it would give you a lof of information
about existing kubernets cluster
5) So as per 4th point the information provided is beyond the information that kubernets api server is providing 
