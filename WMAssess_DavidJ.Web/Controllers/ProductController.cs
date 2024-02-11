using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;
using WMAssess_DavidJ.Services;


namespace ProductCatalogAPI.Controllers
{
    [Route("api/ProductController")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            BusinessResponse busResponse = _productService.GetAllProducts();
            if (busResponse.Success)
            {
                return Ok(busResponse.GetData<List<Product>>());
            }

            return NotFound(busResponse.Message);
        }

        // GET: api/Product/5
        [HttpGet("{sku}")]
        public IActionResult GetProductBySKU(string sku)
        {
            BusinessResponse busResponse = _productService.GetProductBySku(sku);
            if (busResponse.Success)
            {
                return Ok(busResponse.GetData<Product>());
            }
            return NotFound(busResponse.Message);
        }

        //POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            BusinessResponse busResponse = _productService.CreateProduct(product);
            if (busResponse.Success)
            {
                return CreatedAtAction(nameof(GetProductBySKU), new { sku = product.SKU }, product);
            }
            else
            {
                return Conflict(busResponse.Message);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{sku}")]
        public IActionResult UpdateProduct(string sku, [FromBody] Product product)
        {
            BusinessResponse busResponse = _productService.UpdateProduct(product);
            if (busResponse.Success)
            {
                return Ok(busResponse.GetData<Product>());
            }
            return NotFound(busResponse.Message);
        }

        // DELETE: api/Product/5
        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(string sku)
        {
            BusinessResponse busResponse = _productService.DeleteProductBySku(sku);
            if (busResponse.Success)
            {
                return Ok(busResponse.Message);
            }
            return NotFound(busResponse.Message);
        }
    }
}
