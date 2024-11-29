using ControleEstoqueSementes.Controllers;

namespace ControleEstoqueSementes
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioController = new UsuarioController();
            usuarioController.Iniciar();
        }
    }
}
