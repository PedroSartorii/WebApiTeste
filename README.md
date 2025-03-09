# WebApiTeste


# WebApp ASP.NET Core MVC

Este é um projeto ASP.NET Core MVC que implementa um sistema simples de gerenciamento de **Funcionários** e **Projetos**, com operações CRUD e relacionamento entre entidades.

## Estrutura do Projeto

```
Web/
├── Controllers/         # Controladores MVC
├── Data/                # Contexto do banco de dados
├── Migrations/          # Migrações do Entity Framework Core
├── Models/              # Modelos de dados
├── Services/            # Lógica de negócios
├── Views/               # Páginas da interface de usuário (Razor)
├── wwwroot/             # Arquivos estáticos (CSS, JS, Imagens)
├── Properties/          # Configurações do projeto
├── appsettings.json     # Configurações de conexão e ambiente
├── Program.cs           # Ponto de entrada da aplicação
├── Web.csproj           # Arquivo de definição do projeto
```

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (ou superior)
- Banco de dados MySQL
- Visual Studio 2022 (ou outro editor compatível)

##  Configuração do Ambiente

1. **Clone o repositório:**

   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd Web
   ```

2. **Configure a string de conexão no `appsettings.json`:**

   O projeto está configurado para usar MySQL com o **Pomelo.EntityFrameworkCore.MySql**.

   No arquivo `appsettings.json`, configure a conexão:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;port=3306;database=nome_do_banco;user=seu_usuario;password=sua_senha"
   }
   ```

3. **Crie o banco de dados no MySQL:**

   - Crie um banco com o nome definido na sua connection string.
   - O EF Core irá gerar as tabelas automaticamente com as migrações.

## 🛠️ Execução e Migrações

1. **Restaurar pacotes NuGet:**

   ```bash
   dotnet restore
   ```

2. **Aplicar as migrações e criar o banco de dados automaticamente:**

   ```bash
   dotnet ef database update
   ```

   > Se não tiver o `dotnet ef` instalado, execute:
   >
   > ```bash
   > dotnet tool install --global dotnet-ef
   > ```

3. **Executar o projeto:**

   ```bash
   dotnet run
   ```

   Ou execute diretamente pelo Visual Studio (`F5`).

4. **Acesse a aplicação:**

   Normalmente estará disponível em: [https://localhost:5001](https://localhost:5001) ou [http://localhost:5000](http://localhost:5000)

## Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core MVC**
- **Entity Framework Core** com **Pomelo.EntityFrameworkCore.MySql**
- **MySQL** como banco de dados
- **Bootstrap** para a interface responsiva
- **jQuery** para validações e interações de front-end

## Principais Pastas e Arquivos

- `Controllers/` - Controladores como `FuncionarioController.cs` e `ProjetoController.cs`.
- `Models/` - Entidades como `Funcionario.cs`, `Projeto.cs` e `ProjetoFuncionario.cs`.
- `Services/` - Contém a lógica de negócios, como `FuncionarioService.cs`.
- `Views/` - Páginas Razor para interação com o usuário.
- `Migrations/` - Scripts de criação e atualização do banco via EF Core.
- `wwwroot/` - Arquivos estáticos (CSS, JS, Bootstrap).

## Funcionalidades

- Cadastro, edição, visualização e exclusão de Funcionários.
- Cadastro, edição, visualização e exclusão de Projetos.
- Relacionamento entre Funcionários e Projetos.
- Interface amigável com validação de formulários.

## Observações

- **Migrations já estão criadas**, então não é necessário gerar novas, a menos que haja alterações nos modelos.
- As dependências de terceiros estão listadas no `Web.csproj` e serão restauradas automaticamente.
