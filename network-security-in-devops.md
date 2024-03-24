# NETWORK SECURITY IN DEVOPS

- VM accessable with in the company network
- How websites will be accessable with in the company network (internal - intranet)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/4743580f-55b6-4090-ace9-12013fabba37)

## Firewall
- It is a way in which we setup the things so that we decide like how access to the virtual machine or any other resource will be done.
- For example we have create a VM and we need it to accessable from our personal laptop only.
- We have 2 componenets
- INBOUND RULES - We defined from outside how VM will be accessed. ( **We define the ports like 22 for ssh, and application ports 80, 443, 8080 & etc** ), (**We define the source from where access is done, like our Personal IP address only.**) 
- OUTBOUND RULES - All traffic - means to access internet ( for download and etc )

## SENEARIO
- We create a security group to access EC2 instance for security reasons we are using only source as MY IP, But in an organization we have a lof ot employee wants to access it,
- But we don't want to keep it as 0.0.0.0/0 from any ip ssh to ec2 ( with pem key ) for security reasons, How to make it accessable to certain IP addresses.

SOLUTION : **VPN**

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/e4ab2f3d-f662-478d-89d8-b7440a997ffc)

## VPN 
- Private end points -- Private IP address
- VPN is nothing but a application which has multiple private ip addresses.

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/9547d424-e59f-4f0a-b84b-462eec5295a4)
