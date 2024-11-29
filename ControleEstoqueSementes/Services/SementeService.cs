using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ControleEstoqueSementes.Services
{
    public class SementeService
    {
        private readonly JsonStorageService<Semente> _storageService;
        private readonly string _filePath = "sementes.json";
        private List<Semente> sementes;

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

        public void AdicionarSemente(Semente semente)
        {
            semente.Id = sementes.Count + 1;
            sementes.Add(semente);
            _storageService.SaveData(sementes);
        }

        public List<Semente> ListarSementes()
        {
            return sementes.Where(s => !s.Excluida).ToList();
        }

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

        public void ExcluirSemente(int id)
        {
            var semente = sementes.SingleOrDefault(s => s.Id == id);
            if (semente != null)
            {
                semente.Excluida = true;
                _storageService.SaveData(sementes);
            }
        }

        public void RestaurarSemente(int id)
        {
            var semente = sementes.SingleOrDefault(s => s.Id == id);
            if (semente != null)
            {
                semente.Excluida = false;
                _storageService.SaveData(sementes);
            }
        }

        public List<Semente> ListarLixeira()
        {
            return sementes.Where(s => s.Excluida).ToList();
        }
    }
}
