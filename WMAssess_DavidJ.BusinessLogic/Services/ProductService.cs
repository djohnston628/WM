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

    public BusinessResponse GetAllProducts()
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            response.SetData<List<Product>>(_mockData._products);
            response.Success = true;
            return response;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            response.Success = false;
            response.Message = "Error getting products";
            return response;
        }
    }

    public BusinessResponse GetProductBySku(string sku)
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            Product? product = _mockData._products.Find(p => p.SKU == sku);
            if (product != null)
            {
                response.SetData<Product>(product);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Product not found";
            }

            return response;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            response.Success = false;
            response.Message = "Error getting Product";
            return response;
        }
    }

    public BusinessResponse CreateProduct(Product product)
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            product.SKU = Guid.NewGuid().ToString();
            _mockData._products.Add(product);
            response.Success = true;
            response.Message = "Product created";
            response.SetData<Product>(product);
            return response;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            response.Success = false;
            response.Message = "Error creating Product";
            return response;
        }
    }

    public BusinessResponse UpdateProduct(Product product)
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            Product? existingProduct = _mockData._products.Find(p => p.SKU == product.SKU);
            if (existingProduct != null)
            {

                //---BusRule: Check if Buyer was changed, if so notify each buyer of change
                if (!existingProduct.BuyerId.Equals(product.BuyerId, StringComparison.InvariantCultureIgnoreCase))
                {
                    //---NOTE: Going to make an assumtion here that Buyers would be checked for existence before allowing a Buyer change
                    //---       would either add logic here that would check if the new proposed buyer doesn't exist, then either Create one,
                    //---       OR don't allow the change. Not going to write that relation integrity check for the assessment though
                    Buyer? newBuyer = _mockData._buyers.Find(b => b.Id == product.BuyerId);
                    Buyer? prevBuyer = _mockData._buyers.Find(b => b.Id == existingProduct.BuyerId);
                    if (newBuyer != null && prevBuyer != null)
                    {
                        _notification.Notify("SysAdmin", $"Hello {newBuyer.Name}, the product {existingProduct.Title} has switched Buyer from {prevBuyer.Name} to {newBuyer.Name}");
                        _notification.Notify("SysAdmin", $"Hello {prevBuyer.Name}, the product {existingProduct.Title} has switched Buyer from you to {newBuyer.Name}");
                    }
                    existingProduct.BuyerId = product.BuyerId;
                }

                //---BusRule: Check if Product is deactivated, notify the CURRENT Buyer 
                if (existingProduct.Active && !product.Active)
                {
                    existingProduct.Active = product.Active;
                    Buyer? currentBuyer = _mockData._buyers.Find(b => b.Id == existingProduct.BuyerId);
                    if (currentBuyer != null)
                    {
                        _notification.Notify("SysAdmin", $"Hello {currentBuyer.Name}, the product {existingProduct.Title} has been set to Inactive");
                    }
                }


                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;

                response.SetData<Product>(existingProduct);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Product not found";
            }

            return response;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            response.Success = false;
            response.Message = "Error updating Product";
            return response;
        }
    }

    public BusinessResponse DeleteProductBySku(string sku)
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            //var product = _products.Find(p => p.SKU == sku);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //_products.Remove(product);
            //_notifier.Notify(product.SKU, "Product deleted.");

            return response;
        }
        catch (Exception ex)
        {
            _notification.Notify(ex.Message);
            response.Success = false;
            response.Message = "Error deleting Product";
            return response;
        }
    }
}