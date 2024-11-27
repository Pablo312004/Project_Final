# Project_Final

Projeto de Controle de Estoque de Sementes

## Sumário
- [Introdução](#introdução)
- [Requisitos Funcionais](#requisitos-funcionais)
- [Arquitetura e Tecnologias](#arquitetura-e-tecnologias)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Instalação e Execução](#instalação-e-execução)
- [Uso](#uso)
- [Heurística de Nielsen](#heurística-de-nielsen)
- [Contribuições](#contribuições)
- [Licença](#licença)

## Introdução
Este projeto tem como objetivo criar uma aplicação de console para controle de estoque de sementes. A aplicação permite aos usuários e administradores gerenciar o estoque, incluindo funções CRUD (Create, Read, Update, Delete) e pedidos de compra. O projeto é desenvolvido em C# e utiliza o banco de dados PostgreSQL.

## Requisitos Funcionais
### Cadastro de Sementes
- Usuários podem cadastrar novas sementes no sistema, preenchendo informações como nome, categoria, quantidade, preço, fornecedor e data de validade.

### Exibição de Sementes
- O sistema exibe uma lista de todas as sementes cadastradas no estoque.

### Edição de Sementes
- Usuários podem editar os dados de uma semente existente.

### Exclusão de Sementes
- Usuários podem excluir sementes do estoque, com uma confirmação e opção de reversão em até 20 dias.

### Pedido de Compra
- Usuários podem fazer pedidos de compra.
- Admins podem visualizar, aceitar ou negar pedidos de compra.

### Validação de Dados
- O sistema realiza validação dos dados durante o cadastro e edição das sementes.

## Arquitetura e Tecnologias
- **Linguagem de Programação:** C#
- **Banco de Dados:** PostgreSQL
- **IDE:** Visual Studio Code (VSCode)
- **Controle de Acesso:** Implementação de autenticação e controle de permissões

## Estrutura do Projeto
```
ControleEstoqueSementes/
├── Program.cs
├── Models/
│   └── Semente.cs
│   └── Usuario.cs
│   └── PedidoCompra.cs
├── Services/
│   └── SementeService.cs
│   └── UsuarioService.cs
│   └── PedidoCompraService.cs
├── Controllers/
│   └── SementeController.cs
│   └── UsuarioController.cs
│   └── PedidoCompraController.cs
└── Repositories/
    └── SementeRepository.cs
    └── UsuarioRepository.cs
    └── PedidoCompraRepository.cs
```

## Instalação e Execução
### Pré-requisitos
- .NET SDK 5.0 ou superior
- PostgreSQL

### Passos para Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/ControleEstoqueSementes.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd ControleEstoqueSementes
   ```
3. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
4. Compile o projeto:
   ```bash
   dotnet build
   ```

### Execução
1. Execute o projeto:
   ```bash
   dotnet run
   ```

## Uso
### Autenticação
- Ao iniciar a aplicação, o usuário deve se autenticar inserindo o nome de usuário e a senha.

### Menus de Navegação
- Após a autenticação, serão exibidos menus diferentes dependendo se o usuário é admin ou um usuário normal.

#### Menu do Usuário Normal
- Adicionar Semente
- Listar Sementes
- Excluir Semente
- Fazer Pedido de Compra

#### Menu do Admin
- Adicionar Semente
- Listar Sementes
- Editar Semente
- Excluir Semente
- Fazer Pedido de Compra
- Fazer Pedido de Venda
- Visualizar Pedidos de Compra (aceitar ou negar)

## Heurística de Nielsen
- **Controle e Liberdade para o Usuário:**
  - Confirmação antes de excluir sementes e reversão de exclusão por até 20 dias.
  - Mensagens claras de confirmação ao realizar operações críticas.

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado e com direitos autoriais. 




Conclusão:
Este projeto foi desenvolvido com o intuito de demonstrar o uso de ASP.NET Core MVC, C# e PostgreSQL para criar uma aplicação de gerenciamento de estoque simples, mas robusta. Ele fornece uma interface amigável para o usuário realizar operações CRUD e é uma ótima base para futuras melhorias, como a adição de autenticação de usuários ou a criação de relatórios gerenciais.
