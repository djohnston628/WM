using System;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Models.Interfaces
{
    public interface IProductService
    {
        BusinessResponse GetAllProducts();
        BusinessResponse GetProductBySku(string sku);
        BusinessResponse CreateProduct(Product product);
        BusinessResponse UpdateProduct(Product product);
        BusinessResponse DeleteProductBySku(string sku);
    }
}


