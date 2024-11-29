using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoqueSementes.Services
{
    public class UsuarioService
    {
        private readonly JsonStorageService<Usuario> _storageService;
        private readonly string _filePath = "usuarios.json";
        private List<Usuario> usuarios;

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

        public Usuario Autenticar(string nome, string senha)
        {
            return usuarios.SingleOrDefault(u => u.Nome == nome && u.Senha == senha);
        }

        public void AlterarNomeUsuario(int id, string novoNome)
        {
            var usuario = usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.Nome = novoNome;
                _storageService.SaveData(usuarios);
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            return usuarios;
        }

        public void LimparListaUsuarios()
        {
            usuarios.Clear();
            // Re-adicionar os administradores fixos
            usuarios.Add(new Usuario { Id = 1, Nome = "admin1", Senha = "admin123", EhAdmin = true });
            usuarios.Add(new Usuario { Id = 2, Nome = "admin2", Senha = "admin456", EhAdmin = true });
            usuarios.Add(new Usuario { Id = 3, Nome = "admin3", Senha = "admin789", EhAdmin = true });
            _storageService.SaveData(usuarios);
        }
    }
}
