## RECORD FLAG

- IT HELPS IN THE TRACKING THE CHANGES
- UNDERSTAND THE HISTORY OF THE DEPLOYMENT
```
kubectl set image deployment/nginx nginx=nginx:1.16.0 --record
```

## NOTE : --RECORD flag is Duplicated, **Instead of record flag we are using annotate**

Imperative Way: 
```
kubectl create deployment nginx --image=nginx:1.16.0 --replicas 3
```
Declarative Way:
```
apiVersion: apps/v1
kind: Deployment
metadata:
  name: nginx
spec:
  replicas: 3
  selector:
    matchLabels:
      app: nginx
  template:
    metadata:
      labels:
        app: nginx
    spec:
      containers:
      - name: nginx
        image: nginx:1.16.0
        ports:
        - containerPort: 80
```

### To check the history of the deployment
```
kubectl rollout history deployment nginx
```
![image](https://github.com/user-attachments/assets/d7637af5-753f-4f92-a574-65d0f541f677)

### Set the version to latest 
```
kubectl set image deployment nginx nginx=nginx:latest
```
### USING ANNOTATION 
```
kubectl annotate deployment nginx kubernetes.io/change-cause="version change to 1.16.0 to latest" --overwrite=true
```
**THIS SUB COMMAND IS USED TO ANNOTATE KUBERNTES RESOURCES WITH ADDITIONAL METADATA TO KEEP THE RECORDS ANNOTATIONS ARE ARBITARY KEY VALUE PAIRS USED TO ATTACH NON IDENTIFYING METADATA TO OBJECTS**
**This can be used by tools library to store and retrieve arbitary metadata about the resources**

Here ``` kubernetes.io/change-cause ``` - IS THE KEY
``` version change to 1.16.0 to latest `` - IS THE VALUE

### TRACKING THE CHANGES
![image](https://github.com/user-attachments/assets/31debc9d-b5cf-4e75-8540-f07b8fea565b)

- Perviously we have used --record to tack the changes or understand the deployemnt,
- Now we are using ANNOTATE 
