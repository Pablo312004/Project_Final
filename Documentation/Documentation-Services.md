# Controle de Estoque de Sementes
-Services/
-------------------------------------------------------------

Pedido de Compra-

O PedidoCompraService é responsável por gerenciar as operações de persistência dos pedidos de compra de sementes. Ele utiliza um serviço de armazenamento em JSON para salvar e carregar os dados dos pedidos.

Estrutura
Importações
csharp
using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;
ControleEstoqueSementes.Models: Importa o modelo de dados PedidoCompra.

ControleEstoqueSementes.Data: Importa o serviço de armazenamento JsonStorageService.

System.Collections.Generic e System.Linq: Importa bibliotecas padrão do .NET para manipulação de listas e consultas LINQ.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Services
{
    public class PedidoCompraService
    {
        private readonly JsonStorageService<PedidoCompra> _storageService;
        private readonly string _filePath = "pedidosCompra.json";
        private List<PedidoCompra> pedidos;
Define o escopo do serviço dentro do projeto (namespace).

Declara a classe PedidoCompraService.

Cria uma instância de JsonStorageService<PedidoCompra> para gerenciar o armazenamento dos pedidos de compra.

Define a variável _filePath para armazenar o caminho do arquivo JSON.

Cria uma lista pedidos para armazenar os pedidos de compra carregados do arquivo JSON.

Construtor
PedidoCompraService
csharp
public PedidoCompraService()
{
    _storageService = new JsonStorageService<PedidoCompra>(_filePath);
    pedidos = _storageService.LoadData();
}
Função: Inicializa uma nova instância do serviço e carrega os dados dos pedidos de compra do arquivo JSON.

Processo:

Inicializa o JsonStorageService com o caminho do arquivo.

Carrega os dados dos pedidos de compra do arquivo JSON para a lista pedidos.

Métodos
AdicionarPedidoCompra
csharp
public void AdicionarPedidoCompra(PedidoCompra pedido)
{
    pedido.Id = pedidos.Count + 1;
    pedidos.Add(pedido);
    _storageService.SaveData(pedidos);
}
Função: Adiciona um novo pedido de compra à lista de pedidos e salva a lista atualizada no arquivo JSON.

Processo:

Define o Id do novo pedido como a contagem atual de pedidos mais um.

Adiciona o novo pedido à lista pedidos.

Salva a lista atualizada de pedidos no arquivo JSON.

ListarPedidos
csharp
public List<PedidoCompra> ListarPedidos()
{
    return pedidos;
}
Função: Retorna a lista de todos os pedidos de compra.

Processo: Retorna a lista pedidos carregada do arquivo JSON.

AprovarPedido
csharp
public void AprovarPedido(int id)
{
    var pedido = pedidos.SingleOrDefault(p => p.Id == id);
    if (pedido != null)
    {
        pedido.Aprovado = true;
        _storageService.SaveData(pedidos);
    }
}
Função: Marca um pedido de compra como aprovado e salva a lista atualizada no arquivo JSON.

Parâmetro: id - ID do pedido a ser aprovado.

Processo:

Encontra o pedido na lista pedidos com o ID especificado.

Se o pedido for encontrado, define o campo Aprovado como true.

Salva a lista atualizada de pedidos no arquivo JSON.

NegarPedido
csharp
public void NegarPedido(int id)
{
    var pedido = pedidos.SingleOrDefault(p => p.Id == id);
    if (pedido != null)
    {
        pedido.Negado = true;
        _storageService.SaveData(pedidos);
    }
}
Função: Marca um pedido de compra como negado e salva a lista atualizada no arquivo JSON.

Parâmetro: id - ID do pedido a ser negado.

Processo:

Encontra o pedido na lista pedidos com o ID especificado.

Se o pedido for encontrado, define o campo Negado como true.

Salva a lista atualizada de pedidos no arquivo JSON.

------------------------------------------------------------------

Semente Service-

O SementeService é responsável por gerenciar todas as operações relacionadas às sementes, como adicionar, listar, editar, excluir e restaurar sementes. Ele utiliza um serviço de armazenamento em JSON para salvar e carregar os dados das sementes.

Estrutura
Importações
csharp
using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;
using System;
ControleEstoqueSementes.Models: Importa o modelo de dados Semente.

ControleEstoqueSementes.Data: Importa o serviço de armazenamento JsonStorageService.

System.Collections.Generic e System.Linq: Importa bibliotecas padrão do .NET para manipulação de listas e consultas LINQ.

System: Importa funcionalidades básicas do .NET.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Services
{
    public class SementeService
    {
        private readonly JsonStorageService<Semente> _storageService;
        private readonly string _filePath = "sementes.json";
        private List<Semente> sementes;
Define o escopo do serviço dentro do projeto (namespace).

Declara a classe SementeService.

Cria uma instância de JsonStorageService<Semente> para gerenciar o armazenamento das sementes.

Define a variável _filePath para armazenar o caminho do arquivo JSON.

Cria uma lista sementes para armazenar as sementes carregadas do arquivo JSON.

Construtor
SementeService
csharp
public SementeService()
{
    _storageService = new JsonStorageService<Semente>(_filePath);
    sementes = _storageService.LoadData();
    // Inicializar com algumas sementes se estiver vazio
    if (!sementes.Any())
    {
        sementes.AddRange(new List<Semente>
        {
            new Semente { Id = 1, Nome = "Semente de Milho", Categoria = "Cereal", Quantidade = 100, Preco = 10.50m, Fornecedor = "Fornecedor A", DataValidade = DateTime.Now.AddYears(1) },
            new Semente { Id = 2, Nome = "Semente de Soja", Categoria = "Leguminosa", Quantidade = 200, Preco = 12.75m, Fornecedor = "Fornecedor B", DataValidade = DateTime.Now.AddYears(1) },
            new Semente { Id = 3, Nome = "Semente de Trigo", Categoria = "Cereal", Quantidade = 150, Preco = 11.30m, Fornecedor = "Fornecedor C", DataValidade = DateTime.Now.AddYears(1) }
        });
        _storageService.SaveData(sementes);
    }
}
Função: Inicializa uma nova instância do serviço e carrega os dados das sementes do arquivo JSON.

Processo:

Inicializa o JsonStorageService com o caminho do arquivo.

Carrega os dados das sementes do arquivo JSON para a lista sementes.

Se a lista estiver vazia, adiciona algumas sementes iniciais e salva os dados no arquivo JSON.

Métodos
AdicionarSemente
csharp
public void AdicionarSemente(Semente semente)
{
    semente.Id = sementes.Count + 1;
    sementes.Add(semente);
    _storageService.SaveData(sementes);
}
Função: Adiciona uma nova semente ao inventário e salva a lista atualizada no arquivo JSON.

Processo:

Define o Id da nova semente como a contagem atual de sementes mais um.

Adiciona a nova semente à lista sementes.

Salva a lista atualizada de sementes no arquivo JSON.

ListarSementes
csharp
public List<Semente> ListarSementes()
{
    return sementes.Where(s => !s.Excluida).ToList();
}
Função: Retorna a lista de todas as sementes disponíveis no inventário (não excluídas).

Processo:

Filtra a lista sementes para retornar apenas as sementes que não estão excluídas.

Retorna a lista filtrada.

EditarSemente
csharp
public void EditarSemente(Semente semente)
{
    var sementeExistente = sementes.SingleOrDefault(s => s.Id == semente.Id);
    if (sementeExistente != null)
    {
        sementeExistente.Nome = semente.Nome;
        sementeExistente.Categoria = semente.Categoria;
        sementeExistente.Quantidade = semente.Quantidade;
        sementeExistente.Preco = semente.Preco;
        sementeExistente.Fornecedor = semente.Fornecedor;
        sementeExistente.DataValidade = semente.DataValidade;
        _storageService.SaveData(sementes);
    }
}
Função: Edita as informações de uma semente existente e salva a lista atualizada no arquivo JSON.

Processo:

Encontra a semente existente na lista sementes com o ID especificado.

Se a semente for encontrada, atualiza suas informações com os novos valores fornecidos.

Salva a lista atualizada de sementes no arquivo JSON.

ExcluirSemente
csharp
public void ExcluirSemente(int id)
{
    var semente = sementes.SingleOrDefault(s => s.Id == id);
    if (semente != null)
    {
        semente.Excluida = true;
        _storageService.SaveData(sementes);
    }
}
Função: Marca uma semente como excluída e salva a lista atualizada no arquivo JSON.

Parâmetro: id - ID da semente a ser excluída.

Processo:

Encontra a semente na lista sementes com o ID especificado.

Se a semente for encontrada, define o campo Excluida como true.

Salva a lista atualizada de sementes no arquivo JSON.

RestaurarSemente
csharp
public void RestaurarSemente(int id)
{
    var semente = sementes.SingleOrDefault(s => s.Id == id);
    if (semente != null)
    {
        semente.Excluida = false;
        _storageService.SaveData(sementes);
    }
}
Função: Restaura uma semente que foi previamente excluída e salva a lista atualizada no arquivo JSON.

Parâmetro: id - ID da semente a ser restaurada.

Processo:

Encontra a semente na lista sementes com o ID especificado.

Se a semente for encontrada, define o campo Excluida como false.

Salva a lista atualizada de sementes no arquivo JSON.

ListarLixeira
csharp
public List<Semente> ListarLixeira()
{
    return sementes.Where(s => s.Excluida).ToList();
}
Função: Retorna a lista de todas as sementes que foram marcadas como excluídas (lixeira).

Processo:

Filtra a lista sementes para retornar apenas as sementes que estão excluídas.

Retorna a lista filtrada.
---------------------------------------------------------------

Usuario Service-

O UsuarioService é responsável por gerenciar todas as operações relacionadas aos usuários, incluindo registro, autenticação, listagem e gerenciamento de administradores. Ele utiliza um serviço de armazenamento em JSON para salvar e carregar os dados dos usuários.

Estrutura
Importações
csharp
using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;
ControleEstoqueSementes.Models: Importa o modelo de dados Usuario.

ControleEstoqueSementes.Data: Importa o serviço de armazenamento JsonStorageService.

System.Collections.Generic e System.Linq: Importa bibliotecas padrão do .NET para manipulação de listas e consultas LINQ.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Services
{
    public class UsuarioService
    {
        private readonly JsonStorageService<Usuario> _storageService;
        private readonly string _filePath = "usuarios.json";
        private List<Usuario> usuarios;
Define o escopo do serviço dentro do projeto (namespace).

Declara a classe UsuarioService.

Cria uma instância de JsonStorageService<Usuario> para gerenciar o armazenamento dos usuários.

Define a variável _filePath para armazenar o caminho do arquivo JSON.

Cria uma lista usuarios para armazenar os usuários carregados do arquivo JSON.

Construtor
UsuarioService
csharp
public UsuarioService()
{
    _storageService = new JsonStorageService<Usuario>(_filePath);
    usuarios = _storageService.LoadData();
    // Pre-cadastrar três administradores fixos
    if (!usuarios.Any(u => u.EhAdmin))
    {
        usuarios.Add(new Usuario { Id = 1, Nome = "admin1", Senha = "admin123", EhAdmin = true });
        usuarios.Add(new Usuario { Id = 2, Nome = "admin2", Senha = "admin456", EhAdmin = true });
        usuarios.Add(new Usuario { Id = 3, Nome = "admin3", Senha = "admin789", EhAdmin = true });
        _storageService.SaveData(usuarios);
    }
}
Função: Inicializa uma nova instância do serviço e carrega os dados dos usuários do arquivo JSON.

Processo:

Inicializa o JsonStorageService com o caminho do arquivo.

Carrega os dados dos usuários do arquivo JSON para a lista usuarios.

Se não houver administradores cadastrados, adiciona três administradores fixos e salva os dados no arquivo JSON.

Métodos
Registrar
csharp
public Usuario Registrar(string nome, string senha, bool ehAdmin)
{
    if (ehAdmin && usuarios.Count(u => u.EhAdmin) >= 3)
    {
        throw new InvalidOperationException("O número máximo de administradores já foi alcançado.");
    }

    var usuario = new Usuario { Id = usuarios.Count + 1, Nome = nome, Senha = senha, EhAdmin = ehAdmin };
    usuarios.Add(usuario);
    _storageService.SaveData(usuarios);
    return usuario;
}
Função: Registra um novo usuário no sistema e salva a lista atualizada no arquivo JSON.

Parâmetros:

nome - Nome do usuário.

senha - Senha do usuário.

ehAdmin - Indica se o usuário é um administrador.

Processo:

Verifica se o número máximo de administradores já foi alcançado.

Cria um novo usuário com os dados fornecidos.

Adiciona o novo usuário à lista usuarios.

Salva a lista atualizada de usuários no arquivo JSON.

Retorna o novo usuário registrado.

Autenticar
csharp
public Usuario Autenticar(string nome, string senha)
{
    return usuarios.SingleOrDefault(u => u.Nome == nome && u.Senha == senha);
}
Função: Autentica um usuário verificando suas credenciais (nome e senha).

Parâmetros:

nome - Nome do usuário.

senha - Senha do usuário.

Processo:

Procura um usuário na lista usuarios com o nome e senha fornecidos.

Retorna o usuário encontrado ou null se as credenciais não corresponderem.

AlterarNomeUsuario
csharp
public void AlterarNomeUsuario(int id, string novoNome)
{
    var usuario = usuarios.SingleOrDefault(u => u.Id == id);
    if (usuario != null)
    {
        usuario.Nome = novoNome;
        _storageService.SaveData(usuarios);
    }
}
Função: Altera o nome de um usuário existente e salva a lista atualizada no arquivo JSON.

Parâmetros:

id - ID do usuário cujo nome será alterado.

novoNome - Novo nome do usuário.

Processo:

Encontra o usuário na lista usuarios com o ID especificado.

Se o usuário for encontrado, atualiza seu nome com o novo nome fornecido.

Salva a lista atualizada de usuários no arquivo JSON.

ListarUsuarios
csharp
public List<Usuario> ListarUsuarios()
{
    return usuarios;
}
Função: Retorna a lista de todos os usuários cadastrados.

Processo: Retorna a lista usuarios carregada do arquivo JSON.

LimparListaUsuarios
csharp
public void LimparListaUsuarios()
{
    usuarios.Clear();
    // Re-adicionar os administradores fixos
    usuarios.Add(new Usuario { Id = 1, Nome = "admin1", Senha = "admin123", EhAdmin = true });
    usuarios.Add(new Usuario { Id = 2, Nome = "admin2", Senha = "admin456", EhAdmin = true });
    usuarios.Add(new Usuario { Id = 3, Nome = "admin3", Senha = "admin789", EhAdmin = true });
    _storageService.SaveData(usuarios);
}
Função: Limpa a lista de usuários e administradores, mantendo os administradores fixos, e salva a lista atualizada no arquivo JSON.

Processo:

Limpa a lista usuarios.

Adiciona três administradores fixos à lista.

Salva a lista atualizada de usuários no arquivo JSON.