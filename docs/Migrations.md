# Como Mapear e Comandos para Criar Migra��es e Atualizar o Banco de Dados

## Mapeamento de Entidades com Fluent API no EF Core

Neste guia, vamos explicar como mapear entidades utilizando Fluent API no Entity Framework Core (EF Core). A Fluent API � uma forma alternativa de configurar o modelo de dados em compara��o �s conven��es padr�o do EF Core.

## Configura��o B�sica

Para mapear entidades com Fluent API, voc� precisa acessar o m�todo `OnModelCreating` no seu contexto de dados e usar os m�todos fornecidos pela Fluent API para configurar o mapeamento das entidades.

### M�todo `OnModelCreating`

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configura��es de mapeamento de entidades v�o aqui
}
```

### Mapeamento de Propriedades
Voc� pode usar a Fluent API para configurar detalhes sobre as propriedades da sua entidade, como tipo de dados, tamanho m�ximo, chaves prim�rias, chaves estrangeiras, entre outros.


Exemplo de Mapeamento de Propriedades:
```csharp
modelBuilder.Entity<Produto>()
    .Property(p => p.Nome)
    .IsRequired()
    .HasMaxLength(100);

modelBuilder.Entity<Produto>()
    .Property(p => p.Preco)
    .HasColumnType("decimal(18,2)");
```

- Utilize os methodos de extens�o Criados para facilitar mapeamento

```csharp
modelBuilder.Entity<Pedido>()
    .HasOne(p => p.Cliente)
    .WithMany(c => c.Pedidos)
    .HasForeignKey(p => p.ClienteId);
```

## Conclus�o
A Fluent API no EF Core oferece flexibilidade e controle sobre o mapeamento de entidades e seus relacionamentos. Utilize-a para configurar seu modelo de dados de acordo com os requisitos espec�ficos da sua aplica��o.

## Instalar o CLI do Entity Framework Core (EF Core CLI)

```sh
dotnet tool install --global dotnet-ef
```

Este comando instala o CLI do EF Core globalmente em sua m�quina.

## Criar uma Migra��o

Para criar uma migra��o no Entity Framework Core, execute o seguinte comando no terminal ou console, especificando o projeto que cont�m o contexto do banco de dados e as migra��es:

Utilizaremos esta estrutura de comando
`dotnet ef migrations add NomeDaMigracao --project Caminho/Para/Projeto --startup-project Caminho/Para/ProjetoDeInicializacao`

Para isso podemos executar de forma simplificada

```sh
cd ./Foodway.Api
```

```sh
dotnet ef migrations add InitialCreate --project ../Foodway.Infrastructure --startup-project .
```

## Aplicando uma Migra��o
`dotnet ef database update --project Caminho/Para/Projeto --startup-project Caminho/Para/ProjetoDeInicializacao`

### Importante!
Ap�s gerar uma nova Migration, sempre leia o que ela executara antes de Aplicar as Migrations

###
Considerando que estamos no diret�rio do projeto Foodway.API

```sh
dotnet ef database update --project ../Foodway.Infrastructure --startup-project .
```

## Removendo Migrations

Caso Identifique algum problema na Migration criada pode ser removida uma migration executando
```sh
dotnet ef migrations remove --project ../Foodway.Infrastructure --startup-project .
```