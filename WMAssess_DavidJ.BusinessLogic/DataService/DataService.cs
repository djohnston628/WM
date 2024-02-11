using Microsoft.Extensions.Configuration;
using System.Text.Json;

using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Services
{
    /// <summary>
    /// Simple JSON storage for Products and Buyers for assessment purposes
    /// </summary>
    public class DataService: IDataService
    {
        private readonly string _filePathProducts;
        private readonly string _filePathBuyers;
        private readonly IConfiguration _configuration;

        public DataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _filePathProducts = _configuration["FilePathProducts"] ?? "";
            _filePathBuyers = _configuration["FilePathBuyers"] ?? "";
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

        public List<Buyer> GetBuyers()
        {
            if (!File.Exists(_filePathBuyers))
                return new List<Buyer>();

            var jsonData = File.ReadAllText(_filePathBuyers);
            if (jsonData == null || jsonData.Count() == 0)
            {
                return new List<Buyer>();
            }

            return JsonSerializer.Deserialize<List<Buyer>>(jsonData) ?? new List<Buyer>();
        }

        public void SaveBuyer(List<Buyer> buyers)
        {
            var jsonData = JsonSerializer.Serialize(buyers);
            File.WriteAllText(_filePathBuyers, jsonData);
        }
    }
}


