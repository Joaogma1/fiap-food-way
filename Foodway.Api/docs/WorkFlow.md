# Criando um Controller CRUD com .NET Core MVC Web API

Neste guia, vamos explicar como criar um controller CRUD (Create, Read, Update, Delete) usando o .NET Core MVC Web API.

## Passo 1: Criar um Controller

1. Abra o Visual Studio ou o seu editor de código preferido.

2. No Solution Explorer, clique com o botão direito do mouse sobre a pasta `Controllers`, -> V{numero de versão} (selecione "Add" > "Controller"(ou crie um arquivo C#).

3. Todo Controller deve herdar da classe BaseApiController, ela 

4. Dê um nome ao seu controller e clique em "Add".

## Passo 2: Implementar as Operações CRUD

1. No seu novo controller, implemente os métodos para realizar as operações CRUD:
   
   - **GET**: Obter todos os registros.
   - **GET by ID**: Obter um registro específico por ID.
   - **POST**: Criar um novo registro.
   - **PUT**: Atualizar um registro existente.
   - **DELETE**: Excluir um registro.

   Por exemplo:
   ```csharp

   namespace YourNamespace.Controllers
   {
       [Route("api/[controller]")]
       [ApiController]
       public class YourController : BaseApiController
       {
           // GET: api/YourController
           [HttpGet]
           public ActionResult<IEnumerable<string>> Get()
           {
               // Implementação para obter todos os registros
           }

           // GET: api/YourController/5
           [HttpGet("{id}")]
           public ActionResult<string> Get(int id)
           {
               // Implementação para obter um registro por ID
           }

           // POST: api/YourController
           [HttpPost]
           public void Post([FromBody] string value)
           {
               // Implementação para criar um novo registro
           }

           // PUT: api/YourController/5
           [HttpPut("{id}")]
           public void Put(int id, [FromBody] string value)
           {
               // Implementação para atualizar um registro existente
           }

           // DELETE: api/YourController/5
           [HttpDelete("{id}")]
           public void Delete(int id)
           {
               // Implementação para excluir um registro
           }
       }
   }
   ```
### Leia o ControllerBase
- Utilize os methodos de controller base para utilizar IDomain Notification corretamente e os Status HTTP Corretamente

## Padrão Domain Notification

O padrão Domain Notification é uma técnica usada em sistemas baseados em domínio para lidar com validações e notificações de erro de uma forma mais estruturada e coesa. Ele é útil quando se deseja centralizar a lógica de validação em um único local e retornar uma lista de erros para o usuário ou cliente.

### Funcionamento

1. **Validações de Domínio**: As validações de domínio são realizadas dentro das entidades ou serviços do domínio. Isso garante que a lógica de negócios e as regras de validação estejam centralizadas e encapsuladas em seus respectivos contextos.

2. **Notificações de Erro**: Quando uma validação falha, em vez de lançar uma exceção imediatamente, o padrão Domain Notification coleta os erros em uma lista de notificações.

3. **Centralização das Notificações**: As notificações de erro são centralizadas e armazenadas em um objeto específico para notificações, muitas vezes chamado de `Notification` ou `DomainNotification`. Esse objeto é responsável por coletar e gerenciar todas as mensagens de erro durante a execução da operação.

4. **Retorno de Notificações**: Após a conclusão da operação (por exemplo, ao finalizar uma transação de banco de dados), o objeto de notificação é verificado. Se houver notificações de erro, elas são retornadas ao cliente ou usuário.

### Vantagens

- **Centralização da Lógica de Validação**: As regras de validação são centralizadas no próprio domínio, mantendo a coesão e o encapsulamento.
- **Facilidade de Gerenciamento de Erros**: As notificações de erro são coletadas e gerenciadas de forma centralizada, facilitando o tratamento e o retorno ao cliente.
- **Abordagem Não Intrusiva**: Não interfere na estrutura do código existente, permitindo a adição de validações de forma não intrusiva.

## Passo 3 criando um serviço:

### Criando uma Interface

Para criar uma interface em .NET Core, siga estas etapas:

1. Crie uma nova interface utilizando a palavra-chave `interface`.
2. Defina os métodos que a interface deve implementar.

Exemplo:

```csharp
public interface IMyService
{
    void DoSomething();
    string GetResult();
}
```

### Implementando a Interface
Depois de criar a interface, você precisa implementá-la em uma classe concreta. Aqui está como fazer isso:

- Crie uma classe que implementa a interface criada.
- Implemente todos os métodos definidos na interface.

Exemplo:
```csharp
public class MyService : IMyService
{
    public void DoSomething()
    {
        // Implementação da lógica de negócios
    }

    public string GetResult()
    {
        // Implementação da lógica de negócios
        return "Resultado";
    }
}
```

### Adicionando Injeção de Dependência
Para adicionar injeção de dependência em .NET Core, siga estas etapas:

- Registre a interface e sua implementação no contêiner de injeção de dependência.
- Configure o contêiner para fornecer a implementação quando a interface for solicitada.

Exemplo:
```csharp 
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IMyService, MyService>();
}
```

No caso deste aplicação devemos adicionar no arquivo ``ApplicationServicesConfig.cs`` no Projeto `Foodway.Config`

# Padrão Repository em .NET Core

O padrão Repository é um padrão de design comum usado para abstrair o acesso aos dados em um aplicativo. Ele separa a lógica de acesso aos dados da lógica de negócios, facilitando a manutenção e o teste do código.

## Padrão Repository

O padrão Repository consiste em três principais componentes:

1. **Interface Repository**: Define os métodos que serão utilizados para acessar os dados.
2. **Implementação do Repository**: Implementa os métodos definidos na interface, fornecendo a lógica real para acessar os dados.
3. **Contexto de Dados**: Representa a fonte de dados real, como um banco de dados ou serviço de API.

### Funcionamento

1. **Interface Repository**: Define métodos para recuperar dados específicos sem a necessidade de acesso direto ao contexto de dados. Esses métodos podem incluir consultas personalizadas ou operações de filtro.
   
2. **Implementação do Repository**: Implementa os métodos definidos na interface, utilizando o contexto de dados para realizar consultas e retornar os resultados.
   
3. **Uso na Camada de Serviço**: Na camada de serviço ou lógica de negócios, os métodos do Read Repository são invocados para recuperar os dados necessários para atender às demandas do aplicativo.

### Vantagens

- **Abstração do Acesso aos Dados**: Permite que a lógica de negócios trabalhe com uma abstração dos dados, facilitando a substituição do contexto de dados subjacente.
  
- **Melhor Separação de Responsabilidades**: Isola a lógica de acesso aos dados da lógica de negócios, promovendo uma melhor separação de responsabilidades e tornando o código mais fácil de entender e manter.

- **Facilita os Testes Unitários**: Ao usar interfaces e injeção de dependência, é mais fácil testar a lógica de negócios sem a necessidade de acessar um banco de dados real.

## Exemplo de Implementação

### Interface Read Repository

```csharp
public interface IProductReadRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    IEnumerable<Product> GetByCategory(string category);
    // Outros métodos de leitura de dados
}
```

### uso na camada de serviço 
```csharp
public class ProductService
{
    private readonly IProductReadRepository _productReadRepository;

    public ProductService(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return _productReadRepository.GetByCategory(category);
    }

    // Outros métodos de serviço que utilizam o repositório de leitura
}
```

### Pontos de atenção!

- Seguindo o Padrão repository, o código atual utiliza reflection para injetar as dependencias~.
- Utilize como base os padrões utilizado na entidade de dominio Category.