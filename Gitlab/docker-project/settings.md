# Docker access to gitlab-runner

```
 [runners.docker]
    tls_verify = false
    image = "ubuntu"
    privileged = true 
    disable_entrypoint_overwrite = false
    oom_kill_disable = false
    disable_cache = false
    volumes = ["/certs/client","/cache"]
    shm_size = 0
    network_mtu = 0

```

- TO RUN DOCKER IN THE CUSTOM RUNNER
- Change privileged = true & volumes = ["/certs/client"]

# To run docker command inside the docker container

```
default:
  image: docker:latest
  services: 
    - docker:dind
```