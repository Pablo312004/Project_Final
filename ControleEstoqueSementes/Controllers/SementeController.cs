using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;
using System.Collections.Generic;

namespace ControleEstoqueSementes.Controllers
{
    public class SementeController
    {
        private SementeService sementeService = new SementeService();

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

        public List<Semente> ListarSementes()
        {
            var sementes = sementeService.ListarSementes();
            foreach (var semente in sementes)
            {
                Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
            }
            return sementes;
        }

        public void ExibirSementes()
        {
            var sementes = ListarSementes();
            foreach (var semente in sementes)
            {
                Console.WriteLine($"ID: {semente.Id}, Nome: {semente.Nome}, Categoria: {semente.Categoria}, Quantidade: {semente.Quantidade}, Preço: {semente.Preco}, Fornecedor: {semente.Fornecedor}, Data de Validade: {semente.DataValidade:yyyy-MM-dd}");
            }
        }

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

        public void ExcluirSemente()
        {
            Console.Write("ID da Semente: ");
            int id = Convert.ToInt32(Console.ReadLine());
            sementeService.ExcluirSemente(id);
            Console.WriteLine("Semente excluída com sucesso.");
        }

        public void RestaurarSemente()
        {
            Console.Write("ID da Semente: ");
            int id = Convert.ToInt32(Console.ReadLine());
            sementeService.RestaurarSemente(id);
            Console.WriteLine("Semente restaurada com sucesso.");
        }

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
    }
}
