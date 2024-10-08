# CI - Package Registry

- GitLab includes a Package Registry feature that allows you to store and manage
various types of packages such as Maven packages, NPM packages, and more.
You can view your packages for your project by following the below steps:
1.Go to the project
2.Go to Deploy > Package Registry.
- We can use GitLab CI/CD to build or import packages into your package registry


# Container Registry

- GitLab CI/CD (Continuous Integration/Continuous Deployment) and GitLab
Container Registry are powerful features within the GitLab platform that help
automate the software development lifecycle and manage Docker container
images.

- We can check the container registry for our project:
- For a project, select Deploy > Container Registry.
- Note: Only members of a private project will be able to access the container
registry.

### Example

```
stages:
- build

variables:
CONTAINER_REGISTRY: registry.gitlab.com
CONTAINER_IMAGE: $CONTAINER_REGISTRY/your-username/your-project

before_script:
- docker login -u $CI_REGISTRY_USER -p $CI_REGISTRY_PASSWORD $CONTAINER_REGISTRY

build:
stage: build
script:
- docker build -t $CONTAINER_IMAGE .
- docker push $CONTAINER_IMAGE

```