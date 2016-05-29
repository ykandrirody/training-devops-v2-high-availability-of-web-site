# DevOps Training - High availability of web site - Practical / Usage - using Docker compose

[![Build Status](https://travis-ci.org/ykandrirody/training-devops-v2-high-availability-of-web-site.svg?branch=master)](https://travis-ci.org/ykandrirody/training-devops-v2-high-availability-of-web-site)

[Get the PDF of this README](https://gitprint.com/ykandrirody/training-devops-v2-high-availability-of-web-site/blob/master/README.md)


# 1 - Preparation (you can be offline after this step)

## 1.1 - Clone the repository locally
```
git clone https://github.com/ykandrirody/training-devops-v2-high-availability-of-web-site.git
```

## 1.2 - Pull and build the Docker containers
```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-lb.yml pull
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-lb.yml build
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml pull
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml build
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-b.yml pull
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-b.yml build
```

# 2 - Start the practical

## 2.1 - Open this urls :
```
http://localhost:5011/   Web server A.
http://localhost:5012/   Web server B.
http://localhost:5080/   Admin load balancer url
http://localhost:5050/   Frontend load balancer url
```

## 2.2 - Start the load balancer :

```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-lb.yml up -d
```

## 2.3 - Verify :
Admin load balancer : empty

Frontend load balancer : error 404

Web server A : Unreachable

Web server B : Unreachable


## 2.4 - Start the server A :

```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml up -d
```

## 2.5 - Verify :
Admin load balancer : Server A

Frontend load balancer : Server A

Web server A : Reachable

Web server B : Unreachable

## 2.6 - Start the server B :

```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-b.yml up -d
```

## 2.7 - Verify :
Admin load balancer : Server A, Server B

Frontend load balancer : Server A OR Server B

Web server A : Reachable

Web server B : Reachable

## 2.8 - Stop the server A :

```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml kill
```

## 2.9 - Verify :
Admin load balancer : Server B

Frontend load balancer : Server B

Web server A : Unreachable

Web server B : Reachable


# 3 - Deallocate resources
```
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-lb.yml kill
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-lb.yml rm -f -v -a
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml kill
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-a.yml rm -f -v -a
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-b.yml kill
docker-compose -f ./training-devops-v2-high-availability-of-web-site/docker-compose-b.yml rm -f -v -a
```
