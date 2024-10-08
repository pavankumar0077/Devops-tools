# Static Pages websites

- GitLab Pages allows you to publish static websites directly from your repository in
GitLab.
- We can host our site on our own GitLab instance or over GitLab.com for free.
- We can also connect our custom domains and TLS certificate.

### How it works ?

```
Project: Create a project in GitLab, be it public, or private.
Content: Store your website's files within the project repository.
Deployment Folder: GitLab Pages specifically deploys content located in
the public folder within your repository.
CI/CD Configuration: Define a configuration file named .gitlab-ci.yml to
instruct GitLab CI/CD on building and deploying your website.
Pages Job: Within the .gitlab-ci.yml file, you'll define a specific job named
"pages" to initiate the GitLab Pages deployment process.
Domains: You can choose to use either:
GitLab default domain: Your website will be accessible under a
subdomain like your-username.gitlab.io.
Custom domain: If you own a domain, you can configure it with GitLab
Pages for a personalized website address.

````

### Example

```
pages:
  script:
    - mkdir public
    - cp *.html public/
  artifacts:
    paths:
      - public
```

```
stages:
  - build
  - deploy

default:
  image: docker:latest
  services: 
    - docker:dind
variables:
  DOCKER_HOST: "tcp://docker:2375"
  DOCKER_TLS_CERTDIR: ""

build_docker_image:
  stage: build
  # tags:
  #   - aws-ec2 # Custom Runner
  before_script:
    - docker version
  script:
    - echo "Building the project..."
    - docker login registry.gitlab.com -u pavan0077 -p $TOKEN 
    - docker build -t registry.gitlab.com/pavan7521241/webapp-docker .
    - docker push registry.gitlab.com/pavan7521241/webapp-docker
  artifacts:
    paths:
      - $CI_PROJECT_DIR/ # GITLAB PRE-DEFINED VARIABLE
    exclude:
      - Dockerfile # This will not be added to the artifact

pages:
  stage: deploy
  # tags:
  #   - aws-ec2 # Custom Runner
  script:
    - mkdir public
    - cp *.html public/
  artifacts:
    paths:
      - public
```

