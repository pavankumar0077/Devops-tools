# Stages

- In GitLab CI/CD, stages are used to define the order in which your pipeline jobs are executed. Think of stages as sequential steps in your CI/CD pipeline, like Build, Test, Deploy. Jobs in the same stage are executed concurrently, while the next stage starts only after all jobs in the current stage succeed.

- Stages are executed sequentially, but jobs within a stage run in parallel.
This allows for efficient workflow where build jobs, test jobs, etc., are cleanly separated.

- Stage :specific point in CICD piplines

- Stages: collective deivision within the cicd pipelines, There are categorize as build, test, deploy

```
stages:
  - build
  - test
  - deploy

```

# DEFAULT STAGES

- .pre
- build
- test
- deploy
- .post

### NOTE : IF YOU DON'T DEFINE THIS STAGES, IT IS FINE BE'COZ IT IS DEFAULT STAGES

- .pre - it will always be the 1st stage, we cannot change it.
- .post - it will always be the last stage, we cannot change it a well.
- build, test & deploy -> these stages sequence we can changed.


- Script keyword :
- script: "echo Pavan"
- Used to run the commands 


- before_script : We can use before_script to add coammds that must be executed before the job script section commands, it can be single or multiple line commands, 1st before_script will be executed like cicd variables are also be supported here.


- after_script : we can use after_script to add the commands will be executed after each job, including the failed jobs,
- single or multiple lines, cicd varibles are supported, the after_script will be executed in a new shell, which wwill be separete from any before_script or script commands.
- this script will be always be executed even build failed.




