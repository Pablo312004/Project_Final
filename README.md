# Project_Final

Projeto de Controle de Estoque de Sementes:

Introdução:
O Controle de Estoque de Sementes é uma aplicação web desenvolvida com o framework ASP.NET Core MVC, utilizando C# e PostgreSQL como banco de dados relacional. O objetivo principal do projeto é gerenciar o estoque de sementes de uma empresa, permitindo a realização das operações CRUD (Criar, Ler, Atualizar e Excluir) de forma eficiente e intuitiva. A aplicação visa demonstrar os conceitos de desenvolvimento web, manipulação de dados e integração com banco de dados.

Objetivo:
O objetivo do projeto é criar uma aplicação que permita o cadastro, consulta, atualização e exclusão de sementes no estoque. Cada semente possui informações essenciais como nome, categoria, quantidade disponível, preço, fornecedor e data de validade. A aplicação utiliza um banco de dados PostgreSQL para armazenar os dados, proporcionando persistência e segurança.

Requisitos Funcionais

1. Cadastro de Sementes: O usuário pode cadastrar novas sementes no sistema, preenchendo informações como nome, categoria, quantidade, preço, fornecedor e data de validade.

2. Exibição de Sementes: O sistema exibe uma lista de todas as sementes cadastradas no estoque, com informações como nome, categoria, quantidade, preço e fornecedor.

3. Edição de Sementes: O usuário pode editar os dados de uma semente existente. Ao selecionar uma semente da lista, o usuário será redirecionado para uma página de edição, onde poderá alterar as informações.

4. Exclusão de Sementes: O sistema permite que o usuário exclua sementes do estoque, com uma confirmação antes de realizar a exclusão definitiva.

5. Validação de Dados: Durante o cadastro e a edição das sementes, o sistema realiza validação dos dados para garantir que todas as informações necessárias estejam corretas, evitando registros inválidos.


Arquitetura e Tecnologias:

- Frontend: A aplicação utiliza ASP.NET Core MVC (Model-View-Controller), uma arquitetura robusta para aplicações web, que separa a lógica de negócios (Model), a interface com o usuário (View) e a manipulação das requisições HTTP (Controller).
  
- Backend: A lógica de controle de dados e interações com o banco de dados é feita no Controller. O Entity Framework Core (EF Core) é utilizado para gerenciar as interações com o banco de dados PostgreSQL, permitindo as operações CRUD de forma eficiente e segura.

- Banco de Dados: O banco de dados utilizado é o **PostgreSQL**, que armazena todas as informações sobre as sementes no estoque. O banco de dados é configurado para persistir os dados entre as execuções da aplicação, garantindo a integridade e a durabilidade das informações.

- Autenticação e Autorização: Embora este projeto não tenha um sistema de autenticação completo, uma implementação simples de controle de acesso pode ser adicionada para garantir que apenas usuários autorizados possam realizar operações críticas como a exclusão de sementes.


Funcionalidades Implementadas:

1. Cadastro de Sementes*
O usuário pode inserir novas sementes no sistema, fornecendo as seguintes informações:
- **Nome**: Nome da semente.
- **Categoria**: Tipo ou categoria da semente (exemplo: hortaliças, flores, gramíneas, etc.).
- **Quantidade**: Quantidade disponível no estoque.
- **Preço**: Preço unitário da semente.
- **Fornecedor**: Nome do fornecedor da semente.
- **Data de Validade**: Data de validade da semente.


2. Exibição de Sementes
A lista de sementes cadastradas é exibida em uma tabela com as seguintes colunas:
- Nome
- Categoria
- Quantidade
- Preço
- Fornecedor
- Data de validade

Além disso, a tabela inclui links de Editar e Excluir para cada semente.

3. Edição de Sementes
O usuário pode alterar as informações de uma semente. Ao editar, ele será redirecionado para uma página de formulário com os dados atuais da semente, podendo modificá-los conforme necessário.

4. Exclusão de Sementes
O usuário pode excluir sementes do sistema. Antes de realizar a exclusão, o sistema solicita uma confirmação para garantir que o usuário tenha certeza da ação.

5. Validação de Dados
Antes de salvar ou editar uma semente, o sistema valida os dados inseridos pelo usuário, garantindo que os campos obrigatórios estejam preenchidos e que os valores estejam no formato correto (exemplo: preço deve ser numérico e quantidade deve ser positiva).


Tecnologias Utilizadas:

- ASP.NET Core MVC: Framework utilizado para o desenvolvimento da aplicação web.
- C#: Linguagem de programação utilizada para a implementação da lógica do sistema.
- `PostgreSQL: Sistema de gerenciamento de banco de dados relacional utilizado para persistir os dados.
- Entity Framework Core: ORM (Object-Relational Mapping) utilizado para simplificar a interação com o banco de dados.
- HTML, CSS, JavaScript: Linguagens e tecnologias utilizadas para a construção das views (front-end).
- Bootstrap: Framework CSS utilizado para estilizar as páginas e tornar a interface responsiva e amigável.



Estrutura do Projeto:

1. Models
   - **Semente**: Classe que representa a entidade Semente, com as propriedades:
     - `Id`: Identificador único da semente.
     - `Nome`: Nome da semente.
     - `Categoria`: Categoria da semente.
     - `Quantidade`: Quantidade disponível no estoque.
     - `Preco`: Preço unitário da semente.
     - `Fornecedor`: Nome do fornecedor da semente.
     - `DataValidade`: Data de validade da semente.

2. Controllers
   - **SementeController**: Responsável por gerenciar as operações CRUD. Este controller contém as ações:
     - `Index`: Exibe a lista de sementes.
     - `Create`: Exibe o formulário para cadastrar uma nova semente e processa a criação.
     - `Edit`: Exibe o formulário para editar uma semente existente e processa as alterações.
     - `Delete`: Exibe uma confirmação antes de excluir uma semente.
     - `DeleteConfirmed`: Processa a exclusão da semente após a confirmação.

3. Views
   - Index.cshtml: Exibe a lista de sementes com as opções de editar e excluir.
   - Create.cshtml: Formulário para cadastro de novas sementes.
   - Edit.cshtml: Formulário para editar as sementes existentes.
   - Delete.cshtml: Página de confirmação para exclusão de sementes.

4. Banco de Dados (PostgreSQL)
   - Tabela `Sementes` que armazena os dados das sementes no estoque.


Conclusão:
Este projeto foi desenvolvido com o intuito de demonstrar o uso de ASP.NET Core MVC, C# e PostgreSQL para criar uma aplicação de gerenciamento de estoque simples, mas robusta. Ele fornece uma interface amigável para o usuário realizar operações CRUD e é uma ótima base para futuras melhorias, como a adição de autenticação de usuários ou a criação de relatórios gerenciais.
