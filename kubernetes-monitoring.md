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

# After installing promethes now convert promethues server from Cluster Ip to nodePort ip

**Expose Prometheus Service
This is required to access prometheus-server using your browser.**

```kubectl expose service prometheus-server --type=NodePort --target-port=9090 --name=prometheus-server-ext```

How to access prometheus - web ui
--
1) minikube ip
2) prometheus server - port ( get from svc -- kubectl get svc )
3) ``` http://http://192.168.39.30:31683/ (Example) ```


Installation of Grafana 
--

Follow these repo for installation -- ``` https://github.com/pavankumar0077/prometheus-Grafana-Zero-to-Hero/blob/main/Installation/Grafana/helm.md ```

After installing Grafana we need password So kindly read the info provided after installing grafana
--
``` kubectl get secret --namespace default grafana -o jsonpath="{.data.admin-password}" | base64 --decode ; echo ```

# After installing Grafana now convert grafana server from Cluster Ip to nodePort ip

**Expose Grafana Service**
``` kubectl expose service grafana --type=NodePort --target-port=3000 --name=grafana-ext ```


How to access Grafana dashboard - web ui
1) minikube ip
2) grafana server - port (get from svc -- kubectl get svc)
3) http://192.168.39.30:32725/  (Example - IP or port change in your case )
4) username -- admin
5) password -- Use this command to get password ``` kubectl get secret --namespace default grafana -o jsonpath="{.data.admin-password}" | base64 --decode ; echo ```


Adding prometheus as a Data source in the Grafana 
--
1) Like we know Grafana is the visualization platform it will need some metrics to show dashboards
2) Go to data source --> add prometheus
3) Give address of prometheus url (Ex: http://192.168.39.30:31683 )
4) Create dashbord or import 3662 
5) Grafana has a dashboard with common query that everyone required, Like PromQL we need to know PromQL for querying so we already have a  lof ot templates
6) We can get the template from Grafana offical website or other sites as well ``` https://grafana.com/grafana/dashboards/ ```

**To get more information apart from api server then we use kube-state metrics
So 1st we need to convert cluster-Ip to NodePort ip as we get for prometheus and Grafana**
1) To convert to nodeport use this command -- ``` kubectl expose service prometheus-kube-state-metrics --type=NodePort --target-port=8080 --name=prometheus-kube-state-metrics-ext ```
2) Now use minikube ip and port number for web ui : ``` http://192.168.39.30:31670 ```
3) Now you can check all the metrics more then normal kubernetes api server -- So now we can copy any of the query present in the metrics and check in prometheus and execute we get the info as text format same thing we get the
as dashboard or virtualize in the grafana dashboard that't it

4) Now fromt he above url we can see all the metrics in the web ui, But how we will get all the information in the inside the promethues
5) Add ``` http://192.168.39.30:31670/ ``` state-metrics to prmethesus, edit the config-manager using ``` kubectl edit cm prometheus-server ``` and add
6) ![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/44d28816-1670-4f36-997e-c1600ec333f1)
7) Add new job
8) Now let say dev's create a lot of application we have to tell the dev's that to create metrics server using prometheus libraries ( As a devops engineer if we want to write metrics server then we have a good docs as well for it)


VI or VIM
--
1) To insert use press i
2) To save use Esc key and :wq





