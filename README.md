# CRUD: SISTEMA DE PEDIDO

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](<https://dotnet.microsoft.com/pt-br/languages/csharp>)
- [SQL](<https://www.microsoft.com/pt-br/sql-server/sql-server-downloads>)
- [Dapper](<https://www.learndapper.com/>)
- [Entity Framework](<https://www.entityframeworktutorial.net/entityframework6/what-is-entityframework.aspx>)
- [Aspnet Core](<https://dotnet.microsoft.com/pt-br/apps/aspnet>)
- [Git](<https://docs.github.com/pt/contributing/writing-for-github-docs/versioning-documentation>)

### 🛠 Como rodar a aplicação
# Clone este repositório
$ git clone <https://github.com/elirwebGit/Stefanini.Order.BackEnd.git>

# Acesse a pasta: Stefanini.Order.BackEnd\Stefanini.Order\src\Util 
vai no arquivo WebConfig.cs, altera a string de conexão do banco de dados para sua local
segue exemplo: 
$ "Data Source={endereço local da sua maquina};Initial Catalog=Stefanini;User ID={seu usuario};password={sua senha}"

# Após isso acesse a pasta: Stefanini.Order.BackEnd\Stefanini.Order\src\Infra do projeto no terminal/cmd
roda os seguintes comandos

$ cd dotnet ef migrations add "nome que queira dar a sua migration"
$ cd dotnet ef database update

# Execute a aplicação: Stefanini.Order.API (Set as Startup project)
$ dotnet run

# O servidor inciará na porta:7213 - acesse <https://localhost:7213/swagger/index.html>
