# KUBERNETES SERVICE

Why we need service and what happens when there is no service in kubernetes
--

WHEN THEIR IS NO SERVICE OPTION
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9ab47c58-f7c5-42a1-9955-65decd62a433)

1) We deploy pod as a deployment in kubernetes, deployment will crete a replica-set and RS wiil create a POD
2) We have a requirement of creating 3 replica-sets, Let say their are 10 concurrent users (That means users are using the application at same point of time) If it is one replica it usually go down that'y we use multiple replicas
3) No. of replicas depends up on no. of users trying to access the application and no of connections one particular pod can take
4) If a pod goes down then replica-set will create a pod again auto healing but as pervious pod had different IP and now NEWLY CREATED POD AS NEW IP different from old pod
5) The application come up but IP ADDRESS of the application is changed.
6) This application IP should be shared to other teams to work on in prod

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/2f5fee15-c74e-4508-bb1f-90d393aa6d39)

WHEN SERVICE IS THERE
--
1) When a pod goes down, it will create new pod replica-set controller ensures to do that by using auto-healing concept.
2) But after creating new pod it place of old pod the new pod has new IP ADDRESS, so end user or others can not use the application.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/1c10d754-b708-4118-b1c6-231d034f7b0e)
   
4) SO,  TO SOLVE THIS ISSUE WE USE SERVICE ON TOP OF DEPLOYMENT AND THAT WILL ACT AS **LOAD BALANCER** AND WE GIVE THAT SERVICE **IP ADDRESS** TO ACCESS THE APPLICATION TO END USER OR OTHER TEAMS FOR TESTING AND STUFF.
5) Access by using service names, The service internally uses KUBE PROXY 
6) SERVICE usees Kube proxy it will forward the request

EVEN SERVICE IS THERE WE HAVE ONE ISSUE
--
1) When service-name is given instead of pod IP address that's fine, But service should know the new IP address of the pod
2) THis PROBLEM SOLVED  is done by **Service Discovery**



THE ISSUE IS SOLVED BY LABELS & SELECTORS
--

