using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Services;

public class ProductService : IProductService
{
    private Mockdata _mockData;
    private INotify _notification;

    public ProductService()
    {
        _mockData = new Mockdata();
        _notification = new Notification();
    }

    public List<Product>? GetAllProducts()
    { 
        try
        {
            return _mockData._products;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            return null;
        }
    }

    public Product? GetProductBySku(string sku)
    {
        try
        {
            Product? product = _mockData._products.Find(p => p.SKU == sku);
            return product;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            return null;
        }
    }

    public bool CreateProduct(Product product)
    {
        try
        {
            _mockData._products.Add(product);
            return true;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            return false;
        }
    }

    public bool UpdateProduct(Product product)
    {
        try
        {
            //_mockData._products.Add(product);
            return true;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            return false;
        }
    }

    public bool DeleteProductBySku(string sku)
    {
        try
        {
            //_mockData._products.Add(product);
            return true;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            return false;
        }
    }
}