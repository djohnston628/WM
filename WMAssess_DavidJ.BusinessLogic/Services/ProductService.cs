using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;

namespace WMAssess_DavidJ.Services;

public class ProductService : IProductService
{
    private INotify _notification;
    private readonly IDataService _dataService;


    public ProductService(IDataService dataService, INotify notification)
    {
        _notification = notification;
        _dataService = dataService;
    }

    public BusinessResponse GetAllProducts()
    {
        BusinessResponse response = new BusinessResponse();
        try
        {
            response.SetData<List<Product>>(_dataService.GetProducts());
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
            Product? product = _dataService.GetProducts().Find(p => p.SKU == sku);
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
            List<Product> allProducts = _dataService.GetProducts();
            if (allProducts.Exists(p => p.SKU == product.SKU))
            {
                response.Success = false;
                response.Message = "Product with the same SKU already exists.";
            }
            else
            {
                product.SKU = Guid.NewGuid().ToString();
                allProducts.Add(product);
                _dataService.SaveProducts(allProducts);

                response.Success = true;
                response.Message = "Product created";
                response.SetData<Product>(product);
            }
            
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
            List<Product> allProducts = _dataService.GetProducts();
            Product? existingProduct = allProducts.Find(p => p.SKU == product.SKU);
            if (existingProduct != null)
            {

                //---BusRule: Check if Buyer was changed, if so notify each buyer of change
                List<Buyer> allBuyers = _dataService.GetBuyers();
                if (!existingProduct.BuyerId.Equals(product.BuyerId, StringComparison.InvariantCultureIgnoreCase))
                {
                    //---NOTE: Going to make an assumtion here that Buyers would be checked for existence before allowing a Buyer change.
                    //---      Would add logic here that would check if the new proposed buyer doesn't exist, then either Create one,
                    //---      OR don't allow the change. Not going to write that relation integrity check for the assessment though
                    Buyer? newBuyer = allBuyers.Find(b => b.Id == product.BuyerId);
                    Buyer? prevBuyer = allBuyers.Find(b => b.Id == existingProduct.BuyerId);
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
                    Buyer? currentBuyer = allBuyers.Find(b => b.Id == existingProduct.BuyerId);
                    if (currentBuyer != null)
                    {
                        _notification.Notify("SysAdmin", $"Hello {currentBuyer.Name}, the product {existingProduct.Title} has been set to Inactive");
                    }
                }


                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                _dataService.SaveProducts(allProducts);

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
            List<Product> allProducts = _dataService.GetProducts();
            Product? existingProduct = allProducts.Find(p => p.SKU == sku);
            if (existingProduct != null)
            {
                string deletedMessage = $"Product {existingProduct.Title} has been deleted";
                allProducts.Remove(existingProduct);
                _dataService.SaveProducts(allProducts);

                _notification.Notify(deletedMessage);
                response.Success = true;
                response.Message = deletedMessage;
            }
            else
            {
                string notFoundMsg = $"Product with SKU {sku} could not be found for deletion";
                _notification.Notify(notFoundMsg);
                response.Success = false;
                response.Message = notFoundMsg;
            }

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