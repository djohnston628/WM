using System;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Models.Interfaces
{
    public interface IProductService
    {
        List<Product>? GetAllProducts();
        Product? GetProductBySku(string sku);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProductBySku(string sku);
    }
}


