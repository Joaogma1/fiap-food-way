# Como Mapear e Comandos para Criar Migrações e Atualizar o Banco de Dados

## Mapeamento de Entidades com Fluent API no EF Core

Neste guia, vamos explicar como mapear entidades utilizando Fluent API no Entity Framework Core (EF Core). A Fluent API é uma forma alternativa de configurar o modelo de dados em comparação às convenções padrão do EF Core.

## Configuração Básica

Para mapear entidades com Fluent API, você precisa acessar o método `OnModelCreating` no seu contexto de dados e usar os métodos fornecidos pela Fluent API para configurar o mapeamento das entidades.

### Método `OnModelCreating`

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configurações de mapeamento de entidades vão aqui
}
```

### Mapeamento de Propriedades
Você pode usar a Fluent API para configurar detalhes sobre as propriedades da sua entidade, como tipo de dados, tamanho máximo, chaves primárias, chaves estrangeiras, entre outros.


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

- Utilize os methodos de extensão Criados para facilitar mapeamento

```csharp
modelBuilder.Entity<Pedido>()
    .HasOne(p => p.Cliente)
    .WithMany(c => c.Pedidos)
    .HasForeignKey(p => p.ClienteId);
```

## Conclusão
A Fluent API no EF Core oferece flexibilidade e controle sobre o mapeamento de entidades e seus relacionamentos. Utilize-a para configurar seu modelo de dados de acordo com os requisitos específicos da sua aplicação.

## Instalar o CLI do Entity Framework Core (EF Core CLI)

```sh
dotnet tool install --global dotnet-ef
```

Este comando instala o CLI do EF Core globalmente em sua máquina.

## Criar uma Migração

Para criar uma migração no Entity Framework Core, execute o seguinte comando no terminal ou console, especificando o projeto que contém o contexto do banco de dados e as migrações:

Utilizaremos esta estrutura de comando
`dotnet ef migrations add NomeDaMigracao --project Caminho/Para/Projeto --startup-project Caminho/Para/ProjetoDeInicializacao`

Para isso podemos executar de forma simplificada

```sh
cd ./Foodway.Api
```

```sh
dotnet ef migrations add InitialCreate --project ../Foodway.Infrastructure --startup-project .
```

## Aplicando uma Migração
`dotnet ef database update --project Caminho/Para/Projeto --startup-project Caminho/Para/ProjetoDeInicializacao`

### Importante!
Após gerar uma nova Migration, sempre leia o que ela executara antes de Aplicar as Migrations

###
Considerando que estamos no diretório do projeto Foodway.API

```sh
dotnet ef database update --project ../Foodway.Infrastructure --startup-project .
```

## Removendo Migrations

Caso Identifique algum problema na Migration criada pode ser removida uma migration executando
```sh
dotnet ef migrations remove --project ../Foodway.Infrastructure --startup-project .
```