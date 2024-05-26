# Foodway API

## Arquitetura do Projeto & Decis�es Tecnol�gicas

### Decis�es de Arquitetura Hexagonal

O sistema � estruturado usando um padr�o de arquitetura em camadas, especificamente uma vers�o conhecida como Arquitetura de Cebola ou Arquitetura Hexagonal.

- **Camada de Apresenta��o (Presentation Layer)**: Representada pelo projeto `Foodway.Api`. Esta parte da aplica��o � respons�vel por lidar com requisi��es e respostas HTTP, incluindo a modelagem e serializa��o de dados.
- **Camada de Aplica��o (Application Layer)**: Representada pelo projeto `Foodway.Application`. Esta camada � dedicada a lidar com a l�gica de neg�cios, a funcionalidade principal da aplica��o.
- **Camada de Dom�nio (Domain Layer)**: Representada pelo projeto `Foodway.Domain`. Esta camada geralmente � composta por entidades (objetos de neg�cios) e interfaces de reposit�rios.
- **Camada de Infraestrutura (Infrastructure Layer)**: Representada pelo projeto `Foodway.Infrastructure`. Esta camada geralmente encapsula preocupa��es como acesso a dados, acesso ao sistema de arquivos, etc.

### Decis�es Tecnol�gicas

- **.NET Core**
  - **Performance e Escalabilidade**: O .NET Core possui melhorias significativas de performance em rela��o ao .NET Framework. Al�m disso, o ASP.NET Core foi projetado desde o in�cio para suportar e aproveitar ambientes de implanta��o baseados em nuvem e cont�ineres.

- **ASP.NET Core MVC**
  - **Padr�o de Design MVC**: O padr�o de design MVC ajuda a manter a aplica��o melhor organizada e mais f�cil de manter.
  - **Facilidade para construir APIs Web**: Facilita a constru��o de APIs Web, o que pode ser necess�rio para futuras melhorias.

- **Entity Framework Core**
  - **Cria��o de c�digo primeiro e simplifica��o dos testes**: Ajuda a criar c�digo primeiro e simplifica o teste do c�digo de acesso a dados.
  - **Gera��o autom�tica de c�digo de acesso a dados**: Gera automaticamente o c�digo de acesso a dados, o que economiza tempo de desenvolvimento e reduz erros.

- **FluentValidation**
  - **Interface fluente e leg�vel**: Utiliza uma interface fluente e express�es lambda para construir regras de valida��o.
  - **Integra��o com ASP.NET Core**: Pode ser facilmente integrado com o ASP.NET Core, por exemplo, pode substituir o mecanismo de valida��o padr�o do ASP.NET Core.
  - **Regras de valida��o complexas**: Facilita a implementa��o de cen�rios de valida��o complexos que podem ser complicados em valida��es por anota��es de dados.
  - **Teste unit�rio**: Facilita a escrita de testes para suas regras de valida��o.

- **Swashbuckle**
  - **Documenta��o interativa**: Gera automaticamente documenta��o detalhada e interativa da API usando o Swagger UI, facilitando para desenvolvedores front-end e testadores entenderem e trabalharem com suas APIs.
  - **Testabilidade**: Inclui um ambiente de testes embutido que permite aos usu�rios exercitar APIs diretamente na documenta��o. Economiza muito tempo durante as fases de desenvolvimento e teste, permitindo testar APIs sem usar ferramentas externas.

- **XUnit**
  - **Flexibilidade**: N�o imp�e uma estrutura espec�fica para a su�te de testes, permitindo mais flexibilidade no design dos testes.
  - **Suporte a atributos de teste �nicos**: Utiliza nomes de atributos mais intuitivos e �nicos para a organiza��o dos testes comparado a outros frameworks de teste .NET.

- **Moq**
  - **F�cil de usar e flex�vel**: Possui uma API fluente e direta que � f�cil de entender e permite criar mocks de interfaces, classes abstratas, classes, m�todos, propriedades, eventos, delegados ou definir o valor de retorno que pode ser determinado dinamicamente em tempo de execu��o.
