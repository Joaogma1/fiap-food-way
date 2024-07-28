#!/bin/bash

echo "This script will terminate the k8s cluster for this project. Are you sure you want to continue? (y/n)"
read -r response

if [[ "$response" =~ ^[Yy]$ ]]; then
    echo "Deleting all resources related to the project..."

    # Delete deployments
    kubectl delete deployment api postgres

    # Delete services
    kubectl delete service fiapfoodway postgres

    # Delete persistent volume claims
    kubectl delete pvc db-pvc

    # Optionally delete Horizontal Pod Autoscalers if they are used
    kubectl delete hpa api-hpa db-hpa

    # Delete CronJobs
    kubectl delete cronjob scale-up scale-down

    kubectl delete configmap postgres-initdb

    echo "All resources related to the project have been deleted."

else
    echo "Operation cancelled."
fi
