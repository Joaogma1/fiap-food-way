# Contributing to Foodway API

Obrigado por considerar contribuir para o projeto Foodway API! Este documento fornece diretrizes para ajudar você a contribuir de forma eficaz.

## Requisitos de Sistema

Certifique-se de que você tenha as seguintes ferramentas instaladas no seu sistema:

- .NET Core SDK net 8.0 ou superior
- Visual Studio 2022 ou superior, ou Visual Studio Code ou Jetbrains Rider.
- Git
- Docker

## Estrutura do Projeto

A arquitetura do projeto é baseada na Arquitetura Hexagonal (ou Arquitetura de Cebola), que organiza o código em camadas distintas:

Para mais detalhes sobre a estrutura do projeto, consulte [Overview.md](Overview.md).

## Passos para Contribuir

### 1. Faça Clone do Repositório

Clone do repositório.

### 2. Crie um Branch para a Sua Feature

Utilize o fluxo de [Git Flow](https://medium.com/trainingcenter/utilizando-o-fluxo-git-flow-e63d5e0d5e04]) para criar sua branch, consulte referencia para saber mais

```sh
git checkout -b minha-feature
```

### 5. Faça suas Alterações

- Presentation Layer (Foodway.Api): Para adicionar ou modificar endpoints e lógica de roteamento HTTP.
- Application Layer (Foodway.Application): Para lógica de negócios e regras de aplicação.
- Ao criar novos Services a camada de applicação deve-se atualizar o arquivo de Injeção de dependencia. localizado no projeto `Foodway.Config`
- Domain Layer (Foodway.Domain): Para entidades de negócios e interfaces de repositório.
- Infrastructure Layer (Foodway.Infrastructure): Para implementação de acesso a dados, integração com serviços externos, etc.

### 6. Escreva Testes
Certifique-se de adicionar ou modificar testes para cobrir suas alterações:
- Use Moq para criar mocks das dependências.
- Utilize XUnit ou MSTest para escrever testes unitários.

### 7. Valide suas Alterações
Execute todos os testes para garantir que suas alterações não quebrem nada:

```sh
dotnet test
```

### 8. Commit e Push
Faça commit das suas alterações com uma mensagem clara e concisa:
```sh
git add .
git commit -m "Descrição clara da feature ou correção"
git push origin minha-feature
```

### 9. Abra um Pull Request
Abra um pull request no repositório original e descreva as suas alterações detalhadamente.

### 10. Aguardando Revisão
Outros mantenedores revisarão o seu pull request.
Pode ser necessário fazer ajustes com base no feedback.

### Diretrizes de Código
- Siga o padrão de codificação do .NET Core e C#.
- Mantenha o código limpo e bem documentado.
- Siga os princípios da Arquitetura Hexagonal, separando claramente as responsabilidades entre as camadas.

### Comunicação
Seja respeitoso e colaborativo nas comunicações.

Obrigado por contribuir!

A equipe Foodway