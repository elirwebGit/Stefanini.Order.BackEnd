# CRUD: SISTEMA DE PEDIDO

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](<https://dotnet.microsoft.com/pt-br/languages/csharp>)
- [SQL](<https://www.microsoft.com/pt-br/sql-server/sql-server-downloads>)
- [Dapper](<https://www.learndapper.com/>)
- [Entity Framework](<https://www.entityframeworktutorial.net/entityframework6/what-is-entityframework.aspx>)
- [Aspnet Core](<https://dotnet.microsoft.com/pt-br/apps/aspnet>)
- [Git](<https://docs.github.com/pt/contributing/writing-for-github-docs/versioning-documentation>)

### Arquitetura definida para o projeto
Para este projeto foi definido a arquitetura DDD (Domain Design Driven) <br />
Infra -> Essa camada lida com a comunicação com bancos de dados, sistemas externos, frameworks e bibliotecas de infraestrutura, e outros serviços necessários para o funcionamento da aplicação. <br />
<br />
Dominio ->  É onde residem as regras de negócio, lógicas, entidades e todos os conceitos centrais do negócio que a aplicação está tentando resolver <br />
<br />
Application -> É responsável por orquestrar as operações do sistema e gerenciar a interação entre as camadas de domínio e infraestrutura <br />
<br />
Presentation - > A camada de apresentação em uma arquitetura de software, como a proposta pelo Domain-Driven Design (DDD), é responsável pela interação com os usuários ou outros sistemas
<br />

### Funcionalidade da aplicação
POST /api/order -> criação de um novo pedido <br />
GET /api/order -> retornar a lista de pedidos criados <br />
DELETE /api/order/{orderId} -> excluir pedido que se encontra cadastrado na base dados obs: {orderId} é o numero do pedido <br />
PUT /api/order/{orderId} -> atualiza o pedido que se encontra cadastrado na base dados obs: {orderId} é o numero do pedido <br />


### Como rodar a aplicação
 Clone este repositório
```
$ git clone <https://github.com/elirwebGit/Stefanini.Order.BackEnd.git>
```
Acesse a pasta: Stefanini.Order.BackEnd\Stefanini.Order\src\Util\ <br />
vai no arquivo WebConfig.cs, altera a string de conexão do banco de dados para sua local <br />
segue exemplo: <br />

```
$ "Data Source={endereço local da sua maquina};Initial Catalog=Stefanini;User ID={seu usuario};password={sua senha}"<br />
```
Após isso acesse a pasta: Stefanini.Order.BackEnd\Stefanini.Order\src\Infra do projeto no terminal/cmd <br />
roda os seguintes comandos <br />
```
$ cd dotnet ef migrations add "nome que queira dar a sua migration" <br />
$ cd dotnet ef database update <br />
```

Execute a aplicação: Stefanini.Order.API (Set as Startup project) <br />
```
$ dotnet run <br />
```

O servidor inciará na porta:7213 - acesse <https://localhost:7213/swagger/index.html>

<br />
Exemplo de Swagger

```

{
  "customerName": "elir ribeiro",
  "customerEmail": "elirweb@gmail.com",
  "item": [
    {
      "productId": 10,
      "productName": "Mouse",
      "quantity": 3
    },
{
      "productId": 14,
      "productName": "Mouse",
      "quantity": 3
    }
  ]
}
```