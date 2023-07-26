# Docker Bind Mounts & Volumes

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/b36deda7-7f22-42e8-bcf0-54777098cbd4)

Problems with containers
--
1) For example Container (Nginx) is running -- this nginx container will continously puts information about login info like IP address and other info and tries to store in a log file.

2) This logfile is imp, For security checks and last 10 days depending on the organization, time to time you 
perform auditing.

3) For suppose the container gone down, Because of container gone down, The log file will be deleted.
4) Containers are ephemeral or shortlived in nature
5) Container should not have a file system in nature
