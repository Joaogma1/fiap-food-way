#!/bin/bash

echo "Creating all k8s resources for the project..."

kubectl apply -f ./k8s/configmaps/db-config.yml
kubectl apply -f ./k8s/volumes/db-volume.yml
kubectl apply -f ./k8s/database-deployment.yml
kubectl apply -f ./k8s/services/postgres-service.yml
kubectl apply -f ./k8s/fiapfoodway-api-deployment.yml
kubectl apply -f ./k8s/services/api-service.yml
kubectl apply -f ./k8s/hpa/hpa-api.yml
kubectl apply -f ./k8s/hpa/hpa-db.yml
kubectl apply -f ./k8s/crons/scale-up-cronjob.yml
kubectl apply -f ./k8s/crons/scale-down-cronjob.yml

echo "All k8s resources for the project have been recreated."
