
# Controle de Estoque de Sementes - Documentation

PedidoCompraController-
O PedidoCompraController é responsável por gerenciar todas as operações relacionadas aos pedidos de compra de sementes. Ele serve como uma ponte entre os modelos de dados de PedidoCompra e os serviços correspondentes (PedidoCompraService).

Estrutura
Importações
csharp
using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;
using System.Collections.Generic;
ControleEstoqueSementes.Services: Importa os serviços necessários para o funcionamento do controlador.

ControleEstoqueSementes.Models: Importa os modelos de dados, como PedidoCompra e Semente.

System e System.Collections.Generic: Importa bibliotecas padrão do .NET para manipulação de listas e outras funcionalidades básicas.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Controllers
{
    public class PedidoCompraController
    {
        private PedidoCompraService pedidoCompraService = new PedidoCompraService();
Define o escopo do controlador dentro do projeto (namespace).

Declara a classe PedidoCompraController.

Cria uma instância de PedidoCompraService para gerenciar operações de pedidos de compra.

Métodos
FazerPedidoCompra
csharp
public void FazerPedidoCompra(int usuarioId)
{
    var pedido = new PedidoCompra { UsuarioId = usuarioId, Sementes = new List<Semente>() };
    Console.WriteLine("Informe os IDs das sementes para o pedido de compra (digite '0' para finalizar):");
    int id;
    do
    {
        id = Convert.ToInt32(Console.ReadLine());
        if (id != 0)
        {
            var semente = new Semente { Id = id };
            pedido.Sementes.Add(semente);
        }
    } while (id != 0);

    Console.WriteLine("Processando pedido...");
    pedidoCompraService.AdicionarPedidoCompra(pedido);
    Console.WriteLine("Pedido de compra realizado com sucesso!");
}
Função: Cria um novo pedido de compra.

Parâmetro: usuarioId - ID do usuário que está fazendo o pedido.

Processo:

Cria um novo pedido com o usuarioId e uma lista vazia de sementes.

Solicita ao usuário os IDs das sementes, adicionando-as ao pedido até que o usuário insira '0'.

Adiciona o pedido ao serviço de pedidos de compra e confirma a realização do pedido.

ListarPedidos
csharp
public List<PedidoCompra> ListarPedidos()
{
    return pedidoCompraService.ListarPedidos();
}
Função: Retorna uma lista de todos os pedidos de compra.

Processo: Chama o serviço ListarPedidos para obter a lista de pedidos.

AprovarPedido
csharp
public void AprovarPedido(int id)
{
    pedidoCompraService.AprovarPedido(id);
}
Função: Aprova um pedido de compra.

Parâmetro: id - ID do pedido a ser aprovado.

Processo: Chama o serviço AprovarPedido para mudar o status do pedido para aprovado.

NegarPedido
csharp
public void NegarPedido(int id)
{
    pedidoCompraService.NegarPedido(id);
}
Função: Nega um pedido de compra.

Parâmetro: id - ID do pedido a ser negado.

Processo: Chama o serviço NegarPedido para mudar o status do pedido para negado.

ListarPedidos (sobrecarga)
csharp
public List<PedidoCompra> ListarPedidos(int usuarioId)
{
    return pedidoCompraService.ListarPedidos().FindAll(p => p.UsuarioId == usuarioId);
}
Função: Retorna uma lista de todos os pedidos de compra feitos por um usuário específico.

Parâmetro: usuarioId - ID do usuário cujos pedidos serão listados.

Processo: Chama o serviço ListarPedidos, filtrando os pedidos pelo usuarioId.

-------------------------------------------------------------------

SementeController-
O SementeController é responsável por gerenciar todas as operações relacionadas às sementes, como adicionar, listar, editar e excluir sementes do inventário. Ele serve como uma ponte entre o modelo de dados Semente e o serviço correspondente SementeService.

Estrutura
Importações
csharp
using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;
using System.Collections.Generic;
ControleEstoqueSementes.Services: Importa os serviços necessários para o funcionamento do controlador.

ControleEstoqueSementes.Models: Importa os modelos de dados, como Semente.

System e System.Collections.Generic: Importa bibliotecas padrão do .NET para manipulação de listas e outras funcionalidades básicas.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Controllers
{
    public class SementeController
    {
        private SementeService sementeService = new SementeService();
Define o escopo do controlador dentro do projeto (namespace).

Declara a classe SementeController.

Cria uma instância de SementeService para gerenciar operações relacionadas às sementes.

Métodos
AdicionarSemente
csharp
public void AdicionarSemente()
{
    var semente = new Semente();
    Console.Write("Nome: ");
    semente.Nome = Console.ReadLine();
    Console.Write("Categoria: ");
    semente.Categoria = Console.ReadLine();
    Console.Write("Quantidade: ");
    semente.Quantidade = Convert.ToInt32(Console.ReadLine());
    Console.Write("Preço: ");
    semente.Preco = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Fornecedor: ");
    semente.Fornecedor = Console.ReadLine();
    Console.Write("Data de Validade (yyyy-MM-dd): ");
    semente.DataValidade = DateTime.Parse(Console.ReadLine());

    sementeService.AdicionarSemente(semente);
    Console.WriteLine("Semente adicionada com sucesso.");
}
Função: Adiciona uma nova semente ao inventário.

Processo:

Solicita ao usuário informações sobre a semente (nome, categoria, quantidade, preço, fornecedor e data de validade).

Chama o serviço AdicionarSemente para adicionar a nova semente ao inventário.

Confirma a adição com uma mensagem de sucesso.

ListarSementes
csharp
public List<Semente> ListarSementes()
{
    var sementes = sementeService.ListarSementes();
    foreach (var semente in sementes)
    {
        Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
    }
    return sementes;
}
Função: Retorna e exibe uma lista de todas as sementes disponíveis no inventário.

Processo:

Chama o serviço ListarSementes para obter a lista de sementes.

Exibe cada semente com suas informações detalhadas.

Retorna a lista de sementes.

ExibirSementes
csharp
public void ExibirSementes()
{
    var sementes = ListarSementes();
    foreach (var semente in sementes)
    {
        Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
    }
}
Função: Exibe a lista de sementes disponíveis no inventário.

Processo:

Chama o método ListarSementes para obter a lista de sementes.

Exibe cada semente com suas informações detalhadas.

EditarSemente
csharp
public void EditarSemente()
{
    Console.Write("ID da Semente: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var semente = new Semente { Id = id };
    Console.Write("Nome: ");
    semente.Nome = Console.ReadLine();
    Console.Write("Categoria: ");
    semente.Categoria = Console.ReadLine();
    Console.Write("Quantidade: ");
    semente.Quantidade = Convert.ToInt32(Console.ReadLine());
    Console.Write("Preço: ");
    semente.Preco = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Fornecedor: ");
    semente.Fornecedor = Console.ReadLine();
    Console.Write("Data de Validade (yyyy-MM-dd): ");
    semente.DataValidade = DateTime.Parse(Console.ReadLine());

    sementeService.EditarSemente(semente);
    Console.WriteLine("Semente editada com sucesso.");
}
Função: Edita as informações de uma semente existente.

Processo:

Solicita ao usuário o ID da semente a ser editada.

Solicita ao usuário as novas informações da semente (nome, categoria, quantidade, preço, fornecedor e data de validade).

Chama o serviço EditarSemente para atualizar as informações da semente.

Confirma a edição com uma mensagem de sucesso.

ExcluirSemente
csharp
public void ExcluirSemente()
{
    Console.Write("ID da Semente: ");
    int id = Convert.ToInt32(Console.ReadLine());
    sementeService.ExcluirSemente(id);
    Console.WriteLine("Semente excluída com sucesso.");
}
Função: Exclui uma semente do inventário.

Processo:

Solicita ao usuário o ID da semente a ser excluída.

Chama o serviço ExcluirSemente para marcar a semente como excluída.

Confirma a exclusão com uma mensagem de sucesso.

RestaurarSemente
csharp
public void RestaurarSemente()
{
    Console.Write("ID da Semente: ");
    int id = Convert.ToInt32(Console.ReadLine());
    sementeService.RestaurarSemente(id);
    Console.WriteLine("Semente restaurada com sucesso.");
}
Função: Restaura uma semente que foi previamente excluída.

Processo:

Solicita ao usuário o ID da semente a ser restaurada.

Chama o serviço RestaurarSemente para restaurar a semente.

Confirma a restauração com uma mensagem de sucesso.

ListarLixeira
csharp
public void ListarLixeira()
{
    var sementesExcluidas = sementeService.ListarLixeira();
    foreach (var semente in sementesExcluidas)
    {
        Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
    }

    Console.WriteLine("\nDeseja restaurar alguma semente da lixeira? (sim/não)");
    string resposta = Console.ReadLine();
    if (resposta?.ToLower() == "sim")
    {
        RestaurarSemente();
    }
}
Função: Lista todas as sementes que foram marcadas como excluídas (lixeira).

Processo:

Chama o serviço ListarLixeira para obter a lista de sementes excluídas.

Exibe cada semente com suas informações detalhadas.

Pergunta ao usuário se deseja restaurar alguma semente da lixeira e, em caso afirmativo, chama o método RestaurarSemente.

---------------------------------------------------------------
O UsuarioController é responsável por gerenciar todas as interações do usuário com o sistema, incluindo autenticação, registro, navegação e execução de operações específicas para usuários e administradores.

Estrutura
Importações
csharp
using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;
ControleEstoqueSementes.Services: Importa os serviços necessários para o funcionamento do controlador.

ControleEstoqueSementes.Models: Importa os modelos de dados, como Usuario.

System: Importa bibliotecas padrão do .NET para funcionalidades básicas.

Declaração da Classe
csharp
namespace ControleEstoqueSementes.Controllers
{
    public class UsuarioController
    {
        private UsuarioService usuarioService = new UsuarioService();
        private SementeController sementeController = new SementeController();
        private PedidoCompraController pedidoCompraController = new PedidoCompraController();
        private Usuario usuarioLogado;
Define o escopo do controlador dentro do projeto (namespace).

Declara a classe UsuarioController.

Cria instâncias dos serviços e controladores necessários (UsuarioService, SementeController, PedidoCompraController) e uma variável usuarioLogado para armazenar o usuário autenticado.

Métodos
Iniciar
csharp
public void Iniciar()
{
    Console.WriteLine("Bem-vindo ao Sistema de Controle de Estoque de Sementes!");
    int opcao = 0; // Inicialização da variável 'opcao'
    do
    {
        Console.WriteLine("\n1. Entrar como Admin");
        Console.WriteLine("2. Entrar com usuário cadastrado");
        Console.WriteLine("3. Cadastrar novo usuário");
        Console.WriteLine("4. Limpar Console");
        Console.WriteLine("5. Sair");
        opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Autenticar(true);
                break;
            case 2:
                Autenticar(false);
                break;
            case 3:
                RegistrarNovoUsuario();
                break;
            case 4:
                LimparConsole();
                break;
            case 5:
                Console.WriteLine("Saindo do sistema...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao != 5);
}
Função: Exibe o menu principal e permite ao usuário escolher entre login, registro, limpar o console e sair.

Processo:

Exibe opções numeradas para diferentes ações.

Coleta a escolha do usuário e chama os métodos apropriados com base na escolha.

Continua a exibir o menu até que a opção de sair seja selecionada.

LimparConsole
csharp
private void LimparConsole()
{
    Console.Clear();
}
Função: Limpa o conteúdo exibido no console.

Processo: Utiliza o método Console.Clear para limpar a tela.

RegistrarNovoUsuario
csharp
private void RegistrarNovoUsuario()
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = Console.ReadLine();
    Console.Write("Esse usuário será um administrador? (sim/não): ");
    string resposta = Console.ReadLine();
    bool ehAdmin = resposta?.ToLower() == "sim";

    try
    {
        var usuario = usuarioService.Registrar(nome, senha, ehAdmin);
        if (ehAdmin)
        {
            Console.WriteLine("Administrador cadastrado com sucesso. Use suas credenciais para fazer login.");
        }
        else
        {
            Console.WriteLine("Usuário cadastrado com sucesso. Use suas credenciais para fazer login.");
        }
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
Função: Registra um novo usuário no sistema.

Processo:

Coleta informações de nome, senha e se o usuário será um administrador.

Chama o serviço usuarioService.Registrar para registrar o novo usuário.

Exibe uma mensagem de sucesso ou uma mensagem de erro se ocorrer uma exceção.

Autenticar
csharp
private void Autenticar(bool ehAdmin)
{
    Console.Write("\nNome de usuário: ");
    string nome = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = Console.ReadLine();

    usuarioLogado = usuarioService.Autenticar(nome, senha);

    if (usuarioLogado != null)
    {
        if (usuarioLogado.EhAdmin == ehAdmin)
        {
            Console.WriteLine("\nLogin bem-sucedido!");
            if (ehAdmin)
            {
                AdminMenu();
            }
            else
            {
                UsuarioMenu();
            }
        }
        else
        {
            Console.WriteLine("\nCredenciais inválidas ou permissões insuficientes.");
        }
    }
    else
    {
        Console.WriteLine("\nCredenciais inválidas.");
    }
}
Função: Autentica um usuário ou administrador com base nas credenciais fornecidas.

Parâmetro: ehAdmin - Indica se o login é para um administrador.

Processo:

Coleta o nome de usuário e senha.

Chama o serviço usuarioService.Autenticar para autenticar o usuário.

Verifica se a autenticação foi bem-sucedida e se o usuário tem as permissões corretas.

Redireciona para o menu apropriado (usuário ou admin) ou exibe uma mensagem de erro.

UsuarioMenu
csharp
private void UsuarioMenu()
{
    Console.WriteLine($"\nEm que podemos te ajudar, {usuarioLogado.Nome}?");
    int opcao = 0; // Inicialização da variável 'opcao'
    do
    {
        Console.WriteLine("\nVocê deseja:");
        Console.WriteLine("1. Fazer uma compra");
        Console.WriteLine("2. Mais informações");
        Console.WriteLine("3. Limpar Console");
        Console.WriteLine("4. Voltar ao login");
        Console.WriteLine("5. Voltar");
        int escolha = Convert.ToInt32(Console.ReadLine());

        if (escolha == 1)
        {
            CompraMenu();
        }
        else if (escolha == 2)
        {
            InformacoesMenu();
        }
        else if (escolha == 3)
        {
            LimparConsole();
        }
        else if (escolha == 4)
        {
            Iniciar();
            break;
        }
        else if (escolha == 5)
        {
            Console.WriteLine("Voltando ao menu inicial...");
            Iniciar();
            break;
        }
    } while (opcao != 5);
}
Função: Exibe o menu específico para usuários comuns com opções como fazer compras, obter mais informações, limpar o console, voltar ao login ou voltar ao menu inicial.

Processo:

Exibe opções numeradas para diferentes ações.

Coleta a escolha do usuário e chama os métodos apropriados com base na escolha.

Continua a exibir o menu até que a opção de voltar seja selecionada.

CompraMenu
csharp
private void CompraMenu()
{
    int opcao = 0; // Inicialização da variável 'opcao'
    do
    {
        Console.WriteLine("\nMenu de Compra:");
        Console.WriteLine("1. Fazer Pedido de Compra");
        Console.WriteLine("2. Verificar Status de Pedido de Compra");
        Console.WriteLine("3. Verificar Lista de Sementes Disponíveis");
        Console.WriteLine("4. Limpar Console");
        Console.WriteLine("5. Voltar ao login");
        Console.WriteLine("6. Voltar");
        opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                pedidoCompraController.FazerPedidoCompra(usuarioLogado.Id);
                break;
            case 2:
                VisualizarStatusPedido(); // Modificado para exibir apenas "Realizado"
                break;
            case 3:
                VisualizarCatalogo();
                break;
            case 4:
                LimparConsole();
                break;
            case 5:
                Iniciar();
                break;
            case 6:
                Console.WriteLine("Voltando ao menu principal...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao != 6);
}
Função: Exibe o menu de compras com opções para fazer um pedido, verificar status de pedidos, verificar lista de sementes, limpar o console, voltar ao login ou voltar ao menu principal.

Processo:

Exibe opções numeradas para diferentes ações.

Coleta a escolha do usuário e chama os métodos apropriados com base na escolha.

Continua a exibir o menu até que a opção de voltar seja selecionada.

VisualizarStatusPedido
private void VisualizarStatusPedido()
{
    var pedidos = pedidoCompraController.ListarPedidos(usuarioLogado.Id);
    foreach (var pedido in pedidos)
    {
        Console.WriteLine($"Pedido ID: {pedido.Id} - Status: Realizado");
    }
}
Função: Exibe o status de todos os pedidos de compra feitos pelo usuário logado.

Processo:

Chama o serviço ListarPedidos do PedidoCompraController, filtrando pelo usuarioLogado.Id.

Itera sobre a lista de pedidos e exibe o ID do pedido e seu status.

InformacoesMenu
csharp
private void InformacoesMenu()
{
    int opcao = 0; // Inicialização da variável 'opcao'
    do
    {
        Console.WriteLine("\nMenu de Informações:");
        Console.WriteLine("1. Adicionar Semente");
        Console.WriteLine("2. Listar Sementes");
        Console.WriteLine("3. Editar Semente");
        Console.WriteLine("4. Excluir Semente");
        Console.WriteLine("5. Visualizar Lixeira");
        Console.WriteLine("6. Limpar Console");
        Console.WriteLine("7. Voltar ao login");
        Console.WriteLine("8. Voltar");
        opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                sementeController.AdicionarSemente();
                break;
            case 2:
                sementeController.ListarSementes();
                break;
            case 3:
                sementeController.EditarSemente();
                break;
            case 4:
                sementeController.ExcluirSemente();
                break;
            case 5:
                sementeController.ListarLixeira();
                break;
            case 6:
                LimparConsole();
                break;
            case 7:
                Iniciar();
                break;
            case 8:
                Console.WriteLine("Voltando ao menu principal...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao != 8);
}
Função: Exibe o menu de informações para gerenciar sementes, como adicionar, listar, editar, excluir e visualizar a lixeira, além de opções para limpar o console e voltar ao login.

Processo:

Exibe opções numeradas para diferentes ações.

Coleta a escolha do usuário e chama os métodos apropriados com base na escolha.

Continua a exibir o menu até que a opção de voltar seja selecionada.

VisualizarCatalogo
csharp
private void VisualizarCatalogo()
{
    var sementes = sementeController.ListarSementes();
    Console.WriteLine("\nCatálogo de Sementes:");
    foreach (var semente in sementes)
    {
        Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
    }
}
Função: Exibe uma lista detalhada de todas as sementes disponíveis no inventário.

Processo:

Chama o método ListarSementes do SementeController para obter a lista de sementes.

Itera sobre a lista de sementes e exibe suas informações detalhadas, incluindo ID, Nome, Categoria, Quantidade, Preço, Fornecedor e Data de Validade.
------------------------------------------------------------------