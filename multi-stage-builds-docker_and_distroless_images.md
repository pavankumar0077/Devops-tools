```Multi stage Builds ```
```Distroless```


Multi Stage Buids
--
![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c5116680-f5b5-4cce-af5d-d8b1dbe59db7)

This is a simple docker files but here as we can use lof of things are not used to run the application like we are using 
ubuntu which comes with lot of files and there is lot of unnecessary things they are not even used and it results in 
increase in the image size.

To fix this issue Docker introduced Multi stage builds
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/cc2c6ba6-e8b5-4abc-941a-db0f9959c013)


```
Split the docker file in multii parts
=====================================
-- In the stage 1 the docker files will be as but we dont write entrypoint and cmd 
-- from stage 1 we will take only binary or docker image or from stage 1 docker file 
-- The docker image form stage 1 will be placed in stage 2 
-- both stage 1 and stage 2 will remain in one dockerfile only
-- But we have two FROM statements.
-- In stage the FROM -- will have to choice very minimal image, like image that have only python runtime or java 
or etc basically very less size image, or distro images
-- In the stage 2 or final srage we have ENTRYPOINT OR CMD, The advantage with this is we have reduced image size 
significantly so stage 1 content will not be in the final image.
-- Here stage 1 is the build image part
-- Stage 2 will be the final image, it has run time, image form stage 1 and entry point.
```


FOR EXAMPLE: 3 trie application
--

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/1de865fa-093c-41ca-88fb-20452a8bb820)

![image](https://github.com/pavankumar0077/Devops-tools/assets/40380941/c61b89fc-2955-4b36-9ff3-b837017fc420)


NOTE -- Dockerfile has n number of stages but final stage should have only one minimalistic image which has entrypoint or cmd 

