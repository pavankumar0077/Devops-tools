# Gitlab Pipelines

### Jobs
- These define the specific tasks to be peformed, specifying what needs to be done.

### Stages:
- Stages determine when jobs should be run and provide instructions on how they should be executed.

Basic pipeline
--
```
stages:
- build (custom)
- test (custom)

variables:
MY_VAR: "Hello world"

build_job:
 stage: build
 script:
    - echo "Building the project.."

test_job:
 stage: test
 script:
 - echo "Running tests"
 - echo "$MY_VAR"

```

- We can bind multiple jobs in a single stage as well.
- We can run in parallel or in sequence ..
