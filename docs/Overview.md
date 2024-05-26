# Foodway API

## Arquitetura do Projeto & Decisões Tecnológicas

### Decisões de Arquitetura Hexagonal

O sistema é estruturado usando um padrão de arquitetura em camadas, especificamente uma versão conhecida como Arquitetura de Cebola ou Arquitetura Hexagonal.

- **Camada de Apresentação (Presentation Layer)**: Representada pelo projeto `Foodway.Api`. Esta parte da aplicação é responsável por lidar com requisições e respostas HTTP, incluindo a modelagem e serialização de dados.
- **Camada de Aplicação (Application Layer)**: Representada pelo projeto `Foodway.Application`. Esta camada é dedicada a lidar com a lógica de negócios, a funcionalidade principal da aplicação.
- **Camada de Domínio (Domain Layer)**: Representada pelo projeto `Foodway.Domain`. Esta camada geralmente é composta por entidades (objetos de negócios) e interfaces de repositórios.
- **Camada de Infraestrutura (Infrastructure Layer)**: Representada pelo projeto `Foodway.Infrastructure`. Esta camada geralmente encapsula preocupações como acesso a dados, acesso ao sistema de arquivos, etc.

### Decisões Tecnológicas

- **.NET Core**
  - **Performance e Escalabilidade**: O .NET Core possui melhorias significativas de performance em relação ao .NET Framework. Além disso, o ASP.NET Core foi projetado desde o início para suportar e aproveitar ambientes de implantação baseados em nuvem e contêineres.

- **ASP.NET Core MVC**
  - **Padrão de Design MVC**: O padrão de design MVC ajuda a manter a aplicação melhor organizada e mais fácil de manter.
  - **Facilidade para construir APIs Web**: Facilita a construção de APIs Web, o que pode ser necessário para futuras melhorias.

- **Entity Framework Core**
  - **Criação de código primeiro e simplificação dos testes**: Ajuda a criar código primeiro e simplifica o teste do código de acesso a dados.
  - **Geração automática de código de acesso a dados**: Gera automaticamente o código de acesso a dados, o que economiza tempo de desenvolvimento e reduz erros.

- **FluentValidation**
  - **Interface fluente e legível**: Utiliza uma interface fluente e expressões lambda para construir regras de validação.
  - **Integração com ASP.NET Core**: Pode ser facilmente integrado com o ASP.NET Core, por exemplo, pode substituir o mecanismo de validação padrão do ASP.NET Core.
  - **Regras de validação complexas**: Facilita a implementação de cenários de validação complexos que podem ser complicados em validações por anotações de dados.
  - **Teste unitário**: Facilita a escrita de testes para suas regras de validação.

- **Swashbuckle**
  - **Documentação interativa**: Gera automaticamente documentação detalhada e interativa da API usando o Swagger UI, facilitando para desenvolvedores front-end e testadores entenderem e trabalharem com suas APIs.
  - **Testabilidade**: Inclui um ambiente de testes embutido que permite aos usuários exercitar APIs diretamente na documentação. Economiza muito tempo durante as fases de desenvolvimento e teste, permitindo testar APIs sem usar ferramentas externas.

- **XUnit**
  - **Flexibilidade**: Não impõe uma estrutura específica para a suíte de testes, permitindo mais flexibilidade no design dos testes.
  - **Suporte a atributos de teste únicos**: Utiliza nomes de atributos mais intuitivos e únicos para a organização dos testes comparado a outros frameworks de teste .NET.

- **Moq**
  - **Fácil de usar e flexível**: Possui uma API fluente e direta que é fácil de entender e permite criar mocks de interfaces, classes abstratas, classes, métodos, propriedades, eventos, delegados ou definir o valor de retorno que pode ser determinado dinamicamente em tempo de execução.
