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
