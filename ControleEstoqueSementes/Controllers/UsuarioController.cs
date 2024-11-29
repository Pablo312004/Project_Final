using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;

namespace ControleEstoqueSementes.Controllers
{
    public class UsuarioController
    {
        private UsuarioService usuarioService = new UsuarioService();
        private SementeController sementeController = new SementeController();
        private PedidoCompraController pedidoCompraController = new PedidoCompraController();
        private Usuario usuarioLogado;

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

        private void LimparConsole()
        {
            Console.Clear();
        }

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

        private void VisualizarStatusPedido()
        {
            var pedidos = pedidoCompraController.ListarPedidos(usuarioLogado.Id);
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido ID: {pedido.Id} - Status: Realizado");
            }
        }

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

        private void VisualizarCatalogo()
        {
            var sementes = sementeController.ListarSementes();
            Console.WriteLine("\nCatálogo de Sementes:");
            foreach (var semente in sementes)
            {
                Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
            }
        }

        private void AdminMenu()
        {
            Console.WriteLine($"\nEm que podemos te ajudar, {usuarioLogado.Nome}?");
            int opcao = 0; // Inicialização da variável 'opcao'
            do
            {
                Console.WriteLine("\nMenu Admin:");
                Console.WriteLine("1. Adicionar Semente");
                Console.WriteLine("2. Listar Sementes");
                Console.WriteLine("3. Editar Semente");
                Console.WriteLine("4. Excluir Semente");
                Console.WriteLine("5. Fazer Pedido de Venda");
                Console.WriteLine("6. Visualizar Pedidos de Compra");
                Console.WriteLine("7. Aprovar Pedido de Compra");
                Console.WriteLine("8. Negar Pedido de Compra");
                Console.WriteLine("9. Limpar Lista de Usuários");
                Console.WriteLine("10. Limpar Console");
                Console.WriteLine("11. Voltar ao login");
                Console.WriteLine("12. Voltar");
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
                        // Método para fazer pedido de venda pode ser implementado aqui
                        break;
                    case 6:
                        VisualizarPedidosCompra();
                        break;
                    case 7:
                        AprovarPedido();
                        break;
                    case 8:
                        NegarPedido();
                        break;
                    case 9:
                        LimparListaUsuarios();
                        break;
                    case 10:
                        LimparConsole();
                        break;
                    case 11:
                        Iniciar();
                        break;
                    case 12:
                        Console.WriteLine("Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 12);
        }

        private void VisualizarPedidosCompra()
        {
            var pedidos = pedidoCompraController.ListarPedidos();
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido ID: {pedido.Id} - Usuário ID: {pedido.UsuarioId}");
                foreach (var semente in pedido.Sementes)
                {
                    Console.WriteLine($"  Semente ID: {semente.Id}");
                }
                Console.WriteLine($"  Status: {(pedido.Aprovado ? "Aprovado" : pedido.Negado ? "Negado" : "Em Análise")}");
            }
        }

        private void AprovarPedido()
        {
            Console.Write("ID do Pedido para Aprovar: ");
            int idAprovar = Convert.ToInt32(Console.ReadLine());
            pedidoCompraController.AprovarPedido(idAprovar);
            Console.WriteLine("Pedido de compra aprovado.");
        }

        private void NegarPedido()
        {
            Console.Write("ID do Pedido para Negar: ");
            int idNegar = Convert.ToInt32(Console.ReadLine());
            pedidoCompraController.NegarPedido(idNegar);
            Console.WriteLine("Pedido de compra negado.");
        }

        private void LimparListaUsuarios()
        {
            usuarioService.LimparListaUsuarios();
            Console.WriteLine("Lista de usuários e administradores limpa com sucesso.");
        }
    }
}
