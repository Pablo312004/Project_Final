
# Controle de Estoque de Sementes

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
- [Conclusão](#conclusão)

## Introdução
Este projeto tem como objetivo criar uma aplicação de console para controle de estoque de sementes. A aplicação permite aos usuários e administradores gerenciar o estoque, incluindo funções CRUD (Create, Read, Update, Delete) e pedidos de compra. O projeto é desenvolvido em C# e utiliza arquivos JSON para armazenamento de dados.

## Requisitos Funcionais
### Cadastro de Sementes
- Usuários podem cadastrar novas sementes no sistema, preenchendo informações como nome, categoria, quantidade, preço, fornecedor e data de validade.

### Exibição de Sementes
- O sistema exibe uma lista de todas as sementes cadastradas no estoque.

### Edição de Sementes
- Usuários podem editar os dados de uma semente existente.

### Exclusão de Sementes
- Usuários podem excluir sementes do estoque, com uma confirmação e a possibilidade de restauração.

### Pedido de Compra
- Usuários podem fazer pedidos de compra.
- Admins podem visualizar, aprovar ou negar pedidos de compra.

### Validação de Dados
- O sistema realiza validação dos dados durante o cadastro e edição das sementes.

## Arquitetura e Tecnologias
- **Linguagem de Programação:** C#
- **Armazenamento de Dados:** Arquivos JSON
- **IDE:** Visual Studio Code (VSCode)
- **Controle de Acesso:** Implementação de autenticação e controle de permissões

## Estrutura do Projeto
```
ControleEstoqueSementes/
├── Program.cs
├── Models/
│   ├── Semente.cs
│   ├── Usuario.cs
│   └── PedidoCompra.cs
├── Services/
│   ├── SementeService.cs
│   ├── UsuarioService.cs
│   └── PedidoCompraService.cs
├── Controllers/
│   ├── SementeController.cs
│   ├── UsuarioController.cs
│   └── PedidoCompraController.cs
└── Data/
    └── JsonStorageService.cs
```

## Instalação e Execução
### Pré-requisitos
- .NET SDK 5.0 ou superior

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
- **Adicionar Semente:** Permite ao usuário cadastrar uma nova semente.
- **Listar Sementes:** Exibe todas as sementes disponíveis no inventário.
- **Excluir Semente:** Permite excluir uma semente do inventário.
- **Fazer Pedido de Compra:** Permite ao usuário realizar um pedido de compra de sementes.

#### Menu do Admin
- **Adicionar Semente:** Permite ao administrador cadastrar uma nova semente.
- **Listar Sementes:** Exibe todas as sementes disponíveis no inventário.
- **Editar Semente:** Permite editar as informações de uma semente existente.
- **Excluir Semente:** Permite excluir uma semente do inventário.
- **Fazer Pedido de Compra:** Permite ao administrador realizar um pedido de compra de sementes.
- **Visualizar Pedidos de Compra:** Exibe todos os pedidos de compra e permite aprovar ou negar os pedidos.

## Heurística de Nielsen
- **Controle e Liberdade para o Usuário:**
  - Confirmação antes de excluir sementes e possibilidade de restauração.
  - Mensagens claras de confirmação ao realizar operações críticas.
- **Consistência e Padrões:**
  - Interface de usuário consistente com menus claros e opções bem definidas.
- **Prevenção de Erros:**
  - Validação de dados durante o cadastro e edição das sementes para prevenir entradas inválidas.
- **Flexibilidade e Eficiência de Uso:**
  - Funções de gerenciamento acessíveis tanto para usuários comuns quanto para administradores.
  
## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado sob os termos da licença XYZ.

## Conclusão
Este projeto foi desenvolvido com o intuito de demonstrar o uso de C# e arquivos JSON para criar uma aplicação de gerenciamento de estoque simples, mas robusta. Ele fornece uma interface amigável para o usuário realizar operações CRUD e é uma ótima base para futuras melhorias, como a adição de novas funcionalidades ou a integração com outros sistemas.

