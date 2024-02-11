using System;

namespace WMAssess_DavidJ.Models.Interfaces
{
    public interface IDataService
    {
        List<Product> GetProducts();
        void SaveProducts(List<Product> products);
    }
}


