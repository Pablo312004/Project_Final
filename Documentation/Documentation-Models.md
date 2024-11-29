# Controle de Estoque de Sementes
- Models
---------------------------------------------------------
- Pedido de Compra - 

A classe PedidoCompra representa um pedido de compra de sementes. Ela contém informações sobre o pedido, como o ID do pedido, o ID do usuário que fez o pedido, a lista de sementes incluídas no pedido, e o status de aprovação e negação do pedido.

Estrutura
Importações
csharp
using System.Collections.Generic;
System.Collections.Generic: Importa a biblioteca padrão do .NET para manipulação de listas.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Models
{
    public class PedidoCompra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<Semente> Sementes { get; set; }
        public bool Aprovado { get; set; }
        public bool Negado { get; set; }
    }
}
Define o escopo da classe dentro do projeto (namespace).

Declara a classe PedidoCompra.

Define as propriedades da classe.

Propriedades
Id
csharp
public int Id { get; set; }
Função: Armazena o identificador único do pedido de compra.

Tipo: int

UsuarioId
csharp
public int UsuarioId { get; set; }
Função: Armazena o identificador do usuário que fez o pedido de compra.

Tipo: int

Sementes
csharp
public List<Semente> Sementes { get; set; }
Função: Armazena a lista de sementes incluídas no pedido de compra.

Tipo: List<Semente>

Aprovado
csharp
public bool Aprovado { get; set; }
Função: Indica se o pedido de compra foi aprovado.

Tipo: bool

Negado
csharp
public bool Negado { get; set; }
Função: Indica se o pedido de compra foi negado.

Tipo: bool

-------------------------------------------------------------

- Sementes -

A classe Semente representa uma semente no inventário de controle de estoque. Ela contém informações detalhadas sobre a semente, como ID, nome, categoria, quantidade, preço, fornecedor, data de validade e status de exclusão.

Estrutura
Importações
csharp
using System;
System: Importa funcionalidades básicas do .NET, incluindo o tipo DateTime.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Models
{
    public class Semente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string Fornecedor { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Excluida { get; set; }
    }
}
Define o escopo da classe dentro do projeto (namespace).

Declara a classe Semente.

Define as propriedades da classe.

Propriedades
Id
csharp
public int Id { get; set; }
Função: Armazena o identificador único da semente.

Tipo: int

Nome
csharp
public string Nome { get; set; }
Função: Armazena o nome da semente.

Tipo: string

Categoria
csharp
public string Categoria { get; set; }
Função: Armazena a categoria da semente (por exemplo, cereal, leguminosa).

Tipo: string

Quantidade
csharp
public int Quantidade { get; set; }
Função: Armazena a quantidade disponível da semente.

Tipo: int

Preco
csharp
public decimal Preco { get; set; }
Função: Armazena o preço da semente.

Tipo: decimal

Fornecedor
csharp
public string Fornecedor { get; set; }
Função: Armazena o nome do fornecedor da semente.

Tipo: string

DataValidade
csharp
public DateTime DataValidade { get; set; }
Função: Armazena a data de validade da semente.

Tipo: DateTime

Excluida
csharp
public bool Excluida { get; set; }
Função: Indica se a semente foi marcada como excluída.

Tipo: bool

----------------------------------------------------------------

- Usuário

A classe Usuario representa um usuário do sistema de controle de estoque de sementes. Ela contém informações sobre o usuário, como ID, nome, senha e se o usuário é um administrador.

Estrutura
Declaração da Classe
csharp
namespace ControleEstoqueSementes.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool EhAdmin { get; set; }
    }
}
Define o escopo da classe dentro do projeto (namespace).

Declara a classe Usuario.

Define as propriedades da classe.

Propriedades
Id
csharp
public int Id { get; set; }
Função: Armazena o identificador único do usuário.

Tipo: int

Nome
csharp
public string Nome { get; set; }
Função: Armazena o nome do usuário.

Tipo: string

Senha
csharp
public string Senha { get; set; }
Função: Armazena a senha do usuário.

Tipo: string

EhAdmin
csharp
public bool EhAdmin { get; set; }
Função: Indica se o usuário é um administrador.

Tipo: bool
-----------------------------------------------------------

- Arquivo Json:

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ControleEstoqueSementes.Data
{
    public class JsonStorageService<T>
    {
        private readonly string _filePath;

        public JsonStorageService(string filePath)
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new List<T>()));
            }
        }

        public List<T> LoadData()
        {
            try
            {
                var jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados do arquivo JSON: {ex.Message}");
                return new List<T>();
            }
        }

        public void SaveData(List<T> data)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar dados no arquivo JSON: {ex.Message}");
            }
        }
    }
}
