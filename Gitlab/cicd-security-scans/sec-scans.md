# Security Scans


- Static Application Security Testing (SAST): Examines source code, bytecode, or binary code
without executing the program.
- Dynamic Application Security Testing (DAST): Simulates real-world attacks by testing running
applications from the outside.
- Container Security Scans: Focuses on scanning container images for known vulnerabilities.
Dependency Scanning: Identifies vulnerabilities in third-party libraries and dependencies.
- Infrastructure as Code (IaC) Security Scans: Evaluates security configurations in
infrastructure code.
- Interactive Application Security Testing (IAST): Combines elements of SAST and DAST by
testing applications during runtime.
- Secrets Scanning: Scans for hardcoded secrets and credentials in code repositories.
and many more..


# Dynamic Application Security Testing (DAST)

- Simulates real-world attacks by testing running applications from the outside.
- Identifies vulnerabilities that may not be apparent in the source code.
- Provides insights into runtime behavior and potential security weaknesses.

GitLab offers a range of DAST analyzers, and their applicability depends on the type of application you are
testing. For website scanning, you can choose from the following options:

- DAST proxy-based analyzer: Ideal for scanning traditional applications that serve simple HTML. This
analyzer can be executed automatically or on-demand.
- DAST browser-based analyzer: Designed for scanning applications that extensively utilize JavaScript,
including single-page web applications.

### Requirements
- GitLab Runner must be available with the docker executor.
- Application must be deployed, which needs to be scanned.
- dast stage should be added after the deploy job

# Container Security Scans

- Focuses on scanning container images for known vulnerabilities.
- Analyzes dependencies and libraries within containerized applications.
- Ensures that deployed containers do not contain outdated or vulnerable components.
- GitLab integrates with open-source tools for container scanning:
- Trivy
- Grype
- You can enable container scanning by include below job in your existing .gitlab-ci.yml file.
include:
- template: Security/Container-Scanning.gitlab-ci.yml

### Requirements
- GitLab CI/CD pipeline must have a test stage.
- GitLab Runner required with the docker or Kubernetes executor.
- Build and Publish your Docker image to your container registry

# GitLab CI - Infrastructure as Code (IaC) Scanning - Comes under SAST testing

- Evaluates security configurations in infrastructure code.
- Ensures that cloud infrastructure and deployment scripts adhere to security best practices.
- Mitigates misconfigurations that could lead to security vulnerabilities.
Copy and paste the following to the bottom of the .gitlab-ci.yml file
include:
- template: Security/SAST-IaC.gitlab-ci.yml

### Requirements
- GitLab CI/CD pipeline must have a test stage.
- GitLab Runner required with the docker or Kubernetes executor.
