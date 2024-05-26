# Contributing to Foodway API

Obrigado por considerar contribuir para o projeto Foodway API! Este documento fornece diretrizes para ajudar voc� a contribuir de forma eficaz.

## Requisitos de Sistema

Certifique-se de que voc� tenha as seguintes ferramentas instaladas no seu sistema:

- .NET Core SDK net 8.0 ou superior
- Visual Studio 2022 ou superior, ou Visual Studio Code ou Jetbrains Rider.
- Git
- Docker

## Estrutura do Projeto

A arquitetura do projeto � baseada na Arquitetura Hexagonal (ou Arquitetura de Cebola), que organiza o c�digo em camadas distintas:

Para mais detalhes sobre a estrutura do projeto, consulte [Overview.md](Overview.md).

## Passos para Contribuir

### 1. Fa�a Clone do Reposit�rio

Clone do reposit�rio.

### 2. Crie um Branch para a Sua Feature

Utilize o fluxo de [Git Flow](https://medium.com/trainingcenter/utilizando-o-fluxo-git-flow-e63d5e0d5e04]) para criar sua branch, consulte referencia para saber mais

```sh
git checkout -b minha-feature
```

### 5. Fa�a suas Altera��es

- Presentation Layer (Foodway.Api): Para adicionar ou modificar endpoints e l�gica de roteamento HTTP.
- Application Layer (Foodway.Application): Para l�gica de neg�cios e regras de aplica��o.
- Ao criar novos Services a camada de applica��o deve-se atualizar o arquivo de Inje��o de dependencia. localizado no projeto `Foodway.Config`
- Domain Layer (Foodway.Domain): Para entidades de neg�cios e interfaces de reposit�rio.
- Infrastructure Layer (Foodway.Infrastructure): Para implementa��o de acesso a dados, integra��o com servi�os externos, etc.

### 6. Escreva Testes
Certifique-se de adicionar ou modificar testes para cobrir suas altera��es:
- Use Moq para criar mocks das depend�ncias.
- Utilize XUnit ou MSTest para escrever testes unit�rios.

### 7. Valide suas Altera��es
Execute todos os testes para garantir que suas altera��es n�o quebrem nada:

```sh
dotnet test
```

### 8. Commit e Push
Fa�a commit das suas altera��es com uma mensagem clara e concisa:
```sh
git add .
git commit -m "Descri��o clara da feature ou corre��o"
git push origin minha-feature
```

### 9. Abra um Pull Request
Abra um pull request no reposit�rio original e descreva as suas altera��es detalhadamente.

### 10. Aguardando Revis�o
Outros mantenedores revisar�o o seu pull request.
Pode ser necess�rio fazer ajustes com base no feedback.

### Diretrizes de C�digo
- Siga o padr�o de codifica��o do .NET Core e C#.
- Mantenha o c�digo limpo e bem documentado.
- Siga os princ�pios da Arquitetura Hexagonal, separando claramente as responsabilidades entre as camadas.

### Comunica��o
Seja respeitoso e colaborativo nas comunica��es.

Obrigado por contribuir!

A equipe Foodway