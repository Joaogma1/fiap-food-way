#!/bin/bash

echo "Creating all k8s resources for the project..."

kubectl apply -f ./k8s/configmaps/db-config.yml
kubectl apply -f ./k8s/volumes/postgres-pvc.yaml
kubectl apply -f ./k8s/database-deployment.yaml
kubectl apply -f ./k8s/services/postgres-service.yaml
kubectl apply -f ./k8s/fiapfoodway-api-deployment.yaml
kubectl apply -f ./k8s/services/api-service.yaml
kubectl apply -f ./k8s/hpa/hpa-api.yaml
kubectl apply -f ./k8s/hpa/hpa-postgres.yaml
kubectl apply -f ./k8s/crons/scale-up-cronjob.yaml
kubectl apply -f ./k8s/crons/scale-down-cronjob.yaml

echo "All k8s resources for the project have been recreated."
