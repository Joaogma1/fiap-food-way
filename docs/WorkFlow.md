# Criando um Controller CRUD com .NET Core MVC Web API

Neste guia, vamos explicar como criar um controller CRUD (Create, Read, Update, Delete) usando o .NET Core MVC Web API.

## Passo 1: Criar um Controller

1. Abra o Visual Studio ou o seu editor de c�digo preferido.

2. No Solution Explorer, clique com o bot�o direito do mouse sobre a pasta `Controllers`, -> V{numero de vers�o} (selecione "Add" > "Controller"(ou crie um arquivo C#).

3. Todo Controller deve herdar da classe BaseApiController, ela 

4. D� um nome ao seu controller e clique em "Add".

## Passo 2: Implementar as Opera��es CRUD

1. No seu novo controller, implemente os m�todos para realizar as opera��es CRUD:
   
   - **GET**: Obter todos os registros.
   - **GET by ID**: Obter um registro espec�fico por ID.
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
               // Implementa��o para obter todos os registros
           }

           // GET: api/YourController/5
           [HttpGet("{id}")]
           public ActionResult<string> Get(int id)
           {
               // Implementa��o para obter um registro por ID
           }

           // POST: api/YourController
           [HttpPost]
           public void Post([FromBody] string value)
           {
               // Implementa��o para criar um novo registro
           }

           // PUT: api/YourController/5
           [HttpPut("{id}")]
           public void Put(int id, [FromBody] string value)
           {
               // Implementa��o para atualizar um registro existente
           }

           // DELETE: api/YourController/5
           [HttpDelete("{id}")]
           public void Delete(int id)
           {
               // Implementa��o para excluir um registro
           }
       }
   }
   ```
### Leia o ControllerBase
- Utilize os methodos de controller base para utilizar IDomain Notification corretamente e os Status HTTP Corretamente

## Padr�o Domain Notification

O padr�o Domain Notification � uma t�cnica usada em sistemas baseados em dom�nio para lidar com valida��es e notifica��es de erro de uma forma mais estruturada e coesa. Ele � �til quando se deseja centralizar a l�gica de valida��o em um �nico local e retornar uma lista de erros para o usu�rio ou cliente.

### Funcionamento

1. **Valida��es de Dom�nio**: As valida��es de dom�nio s�o realizadas dentro das entidades ou servi�os do dom�nio. Isso garante que a l�gica de neg�cios e as regras de valida��o estejam centralizadas e encapsuladas em seus respectivos contextos.

2. **Notifica��es de Erro**: Quando uma valida��o falha, em vez de lan�ar uma exce��o imediatamente, o padr�o Domain Notification coleta os erros em uma lista de notifica��es.

3. **Centraliza��o das Notifica��es**: As notifica��es de erro s�o centralizadas e armazenadas em um objeto espec�fico para notifica��es, muitas vezes chamado de `Notification` ou `DomainNotification`. Esse objeto � respons�vel por coletar e gerenciar todas as mensagens de erro durante a execu��o da opera��o.

4. **Retorno de Notifica��es**: Ap�s a conclus�o da opera��o (por exemplo, ao finalizar uma transa��o de banco de dados), o objeto de notifica��o � verificado. Se houver notifica��es de erro, elas s�o retornadas ao cliente ou usu�rio.

### Vantagens

- **Centraliza��o da L�gica de Valida��o**: As regras de valida��o s�o centralizadas no pr�prio dom�nio, mantendo a coes�o e o encapsulamento.
- **Facilidade de Gerenciamento de Erros**: As notifica��es de erro s�o coletadas e gerenciadas de forma centralizada, facilitando o tratamento e o retorno ao cliente.
- **Abordagem N�o Intrusiva**: N�o interfere na estrutura do c�digo existente, permitindo a adi��o de valida��es de forma n�o intrusiva.

## Passo 3 criando um servi�o:

### Criando uma Interface

Para criar uma interface em .NET Core, siga estas etapas:

1. Crie uma nova interface utilizando a palavra-chave `interface`.
2. Defina os m�todos que a interface deve implementar.

Exemplo:

```csharp
public interface IMyService
{
    void DoSomething();
    string GetResult();
}
```

### Implementando a Interface
Depois de criar a interface, voc� precisa implement�-la em uma classe concreta. Aqui est� como fazer isso:

- Crie uma classe que implementa a interface criada.
- Implemente todos os m�todos definidos na interface.

Exemplo:
```csharp
public class MyService : IMyService
{
    public void DoSomething()
    {
        // Implementa��o da l�gica de neg�cios
    }

    public string GetResult()
    {
        // Implementa��o da l�gica de neg�cios
        return "Resultado";
    }
}
```

### Adicionando Inje��o de Depend�ncia
Para adicionar inje��o de depend�ncia em .NET Core, siga estas etapas:

- Registre a interface e sua implementa��o no cont�iner de inje��o de depend�ncia.
- Configure o cont�iner para fornecer a implementa��o quando a interface for solicitada.

Exemplo:
```csharp 
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IMyService, MyService>();
}
```

No caso deste aplica��o devemos adicionar no arquivo ``ApplicationServicesConfig.cs`` no Projeto `Foodway.Config`

# Padr�o Repository em .NET Core

O padr�o Repository � um padr�o de design comum usado para abstrair o acesso aos dados em um aplicativo. Ele separa a l�gica de acesso aos dados da l�gica de neg�cios, facilitando a manuten��o e o teste do c�digo.

## Padr�o Repository

O padr�o Repository consiste em tr�s principais componentes:

1. **Interface Repository**: Define os m�todos que ser�o utilizados para acessar os dados.
2. **Implementa��o do Repository**: Implementa os m�todos definidos na interface, fornecendo a l�gica real para acessar os dados.
3. **Contexto de Dados**: Representa a fonte de dados real, como um banco de dados ou servi�o de API.

### Funcionamento

1. **Interface Repository**: Define m�todos para recuperar dados espec�ficos sem a necessidade de acesso direto ao contexto de dados. Esses m�todos podem incluir consultas personalizadas ou opera��es de filtro.
   
2. **Implementa��o do Repository**: Implementa os m�todos definidos na interface, utilizando o contexto de dados para realizar consultas e retornar os resultados.
   
3. **Uso na Camada de Servi�o**: Na camada de servi�o ou l�gica de neg�cios, os m�todos do Read Repository s�o invocados para recuperar os dados necess�rios para atender �s demandas do aplicativo.

### Vantagens

- **Abstra��o do Acesso aos Dados**: Permite que a l�gica de neg�cios trabalhe com uma abstra��o dos dados, facilitando a substitui��o do contexto de dados subjacente.
  
- **Melhor Separa��o de Responsabilidades**: Isola a l�gica de acesso aos dados da l�gica de neg�cios, promovendo uma melhor separa��o de responsabilidades e tornando o c�digo mais f�cil de entender e manter.

- **Facilita os Testes Unit�rios**: Ao usar interfaces e inje��o de depend�ncia, � mais f�cil testar a l�gica de neg�cios sem a necessidade de acessar um banco de dados real.

## Exemplo de Implementa��o

### Interface Read Repository

```csharp
public interface IProductReadRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    IEnumerable<Product> GetByCategory(string category);
    // Outros m�todos de leitura de dados
}
```

### uso na camada de servi�o 
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

    // Outros m�todos de servi�o que utilizam o reposit�rio de leitura
}
```

### Pontos de aten��o!

- Seguindo o Padr�o repository, o c�digo atual utiliza reflection para injetar as dependencias~.
- Utilize como base os padr�es utilizado na entidade de dominio Category.