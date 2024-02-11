using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Services
{
    public class DataService: IDataService
    {
        private readonly string _filePathProducts = "data/products.json";

        public DataService()
        {
            //_filePathProducts = filePathProducts;
        }

        public List<Product> GetProducts()
        {
            if (!File.Exists(_filePathProducts))
                return new List<Product>();

            var jsonData = File.ReadAllText(_filePathProducts);
            if (jsonData == null || jsonData.Count() == 0)
            {
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
        }

        public void SaveProducts(List<Product> products)
        {
            var jsonData = JsonSerializer.Serialize(products);
            File.WriteAllText(_filePathProducts, jsonData);
        }
    }
}


