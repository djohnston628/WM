using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Interfaces;
using WMAssess_DavidJ.Mockdata;
using WMAssess_DavidJ.Common;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/ProductController")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly INotify _notifier;

        // Mock data for buyers
        private readonly List<Buyer> _buyers;

        // for transient product data
        private readonly List<Product> _products;

        public ProductController()
        {
            _notifier = new Notification();

            _buyers = Mockdata._buyers;
            _products = Mockdata._products;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        // GET: api/Product/5
        [HttpGet("{sku}")]
        public IActionResult GetProduct(string sku)
        {
            var product = _products.Find(p => p.SKU == sku);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (_products.Exists(p => p.SKU == product.SKU))
            {
                return Conflict("Product with the same SKU already exists.");
            }

            product.SKU = Guid.NewGuid().ToString();
            _products.Add(product);
            _notifier.Notify(product.SKU, "New product created.");

            return CreatedAtAction(nameof(GetProduct), new { sku = product.SKU }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{sku}")]
        public IActionResult UpdateProduct(string sku, [FromBody] Product product)
        {
            var existingProduct = _products.Find(p => p.SKU == sku);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.BuyerId = product.BuyerId;
            existingProduct.Active = product.Active;

            _notifier.Notify(existingProduct.SKU, "Product updated.");

            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(string sku)
        {
            var product = _products.Find(p => p.SKU == sku);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);
            _notifier.Notify(product.SKU, "Product deleted.");

            return NoContent();
        }
    }
}
