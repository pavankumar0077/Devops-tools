# Templating

- Jobs defined with a leading period (.) are disregarded, rendering .template incapable of
specifying active and executable tasks. This functionality is termed hidden keys.

- YAML permits the referencing of its own segments to prevent redundant copying and
pasting, effectively minimizing code. This capability is known as an "anchor."

- .template: &template
- Where &template is an alias that we can provide to the .template job

- When using "<<: *template,
- " we are instructing to replicate all actions defined in the job
template. If there is a need to modify certain keys already present in the template, it is
necessary to explicitly redefine those keys.

### template example
```
stages:
  - build-test:
      docker_template:
        template_tags:
          - CI-DevOps
      rules:
        - if: $CI_COMMIT_BRANCH == "main"
      timeout: 1 hours 30 minutes

  docker_build_job:
    <<: *templates_stage
    script:
      - echo "Build Started"

  docker_test_job:
    <<: *templates_stage
    script:
      - echo "Test Started"
```

### GitLab CI - extends

- We can use extends to reuse the configuration section

```
.tests:
  image: httpd
  script: 
    - ./test.sh
  stage: test
  timeout: 10m

test_job:
  extends: .tests
  script: 
    - ./new.sh

```

## Example

```
stages:
  - build
  - test
  - deploy

default:
  image: docker:latest
  services: 
    - docker:dind
variables:
  DOCKER_HOST: "tcp://docker:2375"
  DOCKER_TLS_CERTDIR: ""

.docker_template: &template # We are using template to reuse in the code, As we are using custom runner aws-ec2 and we need to use it in all the stages, instead we can define a template and use the template.
  tags:
    - aws-ec2

# Build the Docker image
build_docker_image:
  <<: *template # instead of tags using template
  stage: build
  before_script:
    - docker version
  script:
    - echo "Building the project..."
    - docker login registry.gitlab.com -u pavan0077 -p $TOKEN 
    - docker build -t registry.gitlab.com/pavan7521241/webapp-docker:$CI_PIPELINE_IID .
    - docker push registry.gitlab.com/pavan7521241/webapp-docker:$CI_PIPELINE_IID
  artifacts:
    paths:
      - $CI_PROJECT_DIR/
    exclude:
      - Dockerfile
  allow_failure: true  # Allows the pipeline to continue even if this stage fails

# Test the Docker image
test_docker_image:
  <<: *template # instead of tags using template
  stage: test
  script:
    - echo "Testing the project..."
    - docker login registry.gitlab.com -u pavan0077 -p $TOKEN 
    - docker pull registry.gitlab.com/pavan7521241/webapp-docker:$CI_PIPELINE_IID
    - docker image ls
  allow_failure: true  # Allows the pipeline to continue even if this stage fails

# Deploy and run the Docker image in the dev environment
deploy_to_dev:
  <<: *template # instead of tags using template
  stage: deploy
  environment:
    name: dev
  script:
    - echo "Deploying and running the Docker container in dev..."
    - docker login registry.gitlab.com -u pavan0077 -p $TOKEN
    - docker pull registry.gitlab.com/pavan7521241/webapp-docker:$CI_PIPELINE_IID
    
    # Stop any running container
    - docker stop dev-container || true
    - docker rm dev-container || true
    
    # Run the Docker container
    - docker run -d --name dev-container -p 8080:80 registry.gitlab.com/pavan7521241/webapp-docker:$CI_PIPELINE_IID
    
    # Test if the application is running within the container
    - docker exec dev-container curl -f http://localhost:80 || echo "App is not running"
    
    # Optionally, check the running container
    - docker ps | grep dev-container

```