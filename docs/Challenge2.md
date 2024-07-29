# FIAP-TechChallenge 2
Documentos referentes à etapa 2 do Tech Challenge

## Entregável 2
a. Desenho da arquitetura pensado por você, pessoa arquiteta de software, contemplando:
	- Os requisitos do negócio (problema).
	- Os requisitos de infraestrutura:
	  1	. Você pode utilizar o MiniKube, Docker Kubernetes, AKS, EKS, GKE ou qualquer nuvem que você desenha.

b. Collection com todas as APIs desenvolvidas com exemplo de requisição (que não seja vazia):
	- Link do Swagger no projeto ou link para download da collection do Postman (JSON).

c. Guia completo com todas as instruções para execução do projeto e a ordem de execução das APIs, caso seja necessário.

d. Link para vídeo demonstrando a arquitetura desenvolvida na nuvem ou localmente

i. O vídeo deve ser postado no Youtube ou Vimeo.
	- Não esqueça de deixá-lo público ou não listado.

# Desenho da arquitetura

## Requisitos do negócio:
Para a entrega 2, visando a clean architecture, foi pensado em usar o Mediatr que é uma bibilioteca que permite  centralizar o fluxo de comunicação entre os objetos, mesmo que estes não conheçam um ao outro. 
Desta forma, foi possível criar um código mais limpo e sustentável, visto que a integração com o Entity Framework, permitiu o desenvolvimento independente de cada objeto, visto que cada ação é tratada isoladamente, facilitando assim sua alteração quando necessário. 

Os componentes principais são os requests e os handlers
- Os requests possuem as propriedades necessárias para solicitar o input dos dados aos handlers.
- Os Handlers, por sua vez, fazem o processamento destas requisições.

Abaixo segue o desenho da arquitetura no projeto.

![FoodWay - Clean Architecture with mediatR](images/FoodWay%20-%20Clean%20Architecture%20with%20mediator.png)

## Guia K8s
 - Ler arquivo README.md
 ------------------------------------------------------
