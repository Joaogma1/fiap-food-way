# Fiap-food-way

## Requisitos de Sistema

Certifique-se de que você tenha as seguintes ferramentas instaladas no seu sistema:

- .NET Core SDK net 8.0 ou superior
- Visual Studio 2022 ou superior, ou Visual Studio Code ou Jetbrains Rider.
- Git

Ou
- Docker

## Rodando a aplicação no Docker
Utilize o **_docker compose_** na pasta root do Projeto:

```sh
docker-compose up -d
```
Podera encontrar o Swagger da aplicação na URL

`http://localhost:8080/swagger/index.html`

Ou 

[Clique Aqui !](http://localhost:8080/swagger/index.html)


## Rodando a aplicação em um cluster K8s

Certifique-se que o kubernetes esteja instalando em sua máquina.

- [Kubernetes](https://kubernetes.io/releases/download/)

> Sempre que atualizar a aplicação lembre-se de gerar uma nova build do docker e recriar o `kubeclt apply -f ./k8s/fiapfoodway-api-deployment.yml`

### Utilizando minikube

Primeiro certifique-se que o `minikube` esteja instalado em sua máquina.

- [Minikube](https://minikube.sigs.k8s.io/docs/start/?arch=%2Fmacos%2Fx86-64%2Fstable%2Fbinary+download)

Siga o passo a passo a seguir para rodar o minikube e o cluster k8s dessa aplicação:

1. "Ligue" o minikube

```bash
minikube start
```

2. "Builde" a aplicação

```bash
docker build -t fiapfoodway/api:latest .
```

3. Certifique-se que o minikube pode "ver" suas imagens de docker local:

```bash
eval $(minikube -p minikube docker-env)
```

4. Crie os recursos:

Pode cria-los utilizando o `tools/build-k8s.sh`
```bash
bash ./tools/build-k8s.sh
```

ou

```bash
kubectl apply -f ./k8s/configmaps/db-config.yml
kubectl apply -f ./k8s/volumes/db-pvc.yml
kubectl apply -f ./k8s/database-deployment.yml
kubectl apply -f ./k8s/services/postgres-service.yml
kubectl apply -f ./k8s/fiapfoodway-api-deployment.yml
kubectl apply -f ./k8s/services/api-service.yml
kubectl apply -f ./k8s/hpa/hpa-api.yml
kubectl apply -f ./k8s/hpa/hpa-postgres.yml
kubectl apply -f ./k8s/crons/scale-up-cronjob.yml
kubectl apply -f ./k8s/crons/scale-down-cronjob.yml
```

5. Certifique-se que os pods estão rodando corretamente:

```bash
kubectl get pods
```

6. No mesmo terminal rode libere as portas para o load balancer

```bash
minikube tunnel
```

Em caso de sucesso o terminal irá expor o seguinte:

```bash
✅  Tunnel successfully started

📌  NOTE: Please do not close this terminal as this process must stay alive for the tunnel to be accessible ...

🏃  Starting tunnel for service fiapfoodway
```

> Mantenha o terminal aberto para manter a aplicação com o tunnel aberto para o load balancer

7. Abra um segundo terminal e digite

```bash
minikube service fiapfoodway --url
```

O terminal irá expor algo do tipo:
```bash
minikube service fiapfoodway --url
http://127.0.0.1:62511
❗  Because you are using a Docker driver on darwin, the terminal needs to be open to run it.
```

Essa url é a url atual da aplicação

> Mantenha o terminal aberto para manter a url exposta para a API

Teste a url: `{--url}/swagger/index.html`

### Troubleshooting

Lembre-se de primeiramente checar os logs:

```bash
kubectl logs deployments/api
ou
kubectl logs deployments/potegres
```

#### CrashLoop por falha de migration

Em caso de falha com a migration, libere o volume para re-criar o banco de dados:

```bash
kubectl delete pvc db-pvc
```

```bash
kubectl apply -f ./k8s/volumes/db-pvc.yml
kubectl apply -f ./k8s/database-deployment.yml
kubectl apply -f ./k8s/services/postgres-service.yml
```

#### Hard refresh

Se tudo falhar, tente deletar tudo e começar novamente

```bash
bash ./tools/terminate-k8s.sh
```

E reconstrua novamente tentando identificar onde esta a falha