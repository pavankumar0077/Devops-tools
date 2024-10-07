# Regisger Gitlab runner in EC2

- ![alt text](image.png)
- We can try on and off shared runner 
- ![alt text](image-1.png)
- ![alt text](image-2.png)
- ![alt text](image-3.png)


# install runner in ec2
- ![alt text](image-4.png)
- ![alt text](image-5.png)

# Add gitlab user as sudoers
- ``` nano /etc/sudoers ```
- ![alt text](image-6.png)
- ![alt text](image-7.png)

# Install Docker
- ``` yum -y update```
- ``` yum install docker ```
- ``` systemctl start docker ```
- ``` systemctl enable docker ```
- ``` systemctl status docker ```


# Runner concurrent limit
- ![alt text](image-8.png)
- ![alt text](image-9.png)

# Restart gitlab-runner
- gitlab-runner restart
- gitlab-runner status

