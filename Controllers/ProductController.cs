using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeneralStoreAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class ProductController : Controller   
    {
        private GeneralStoreDBContext _db;
        public ProductController(GeneralStoreDBContext db)
        {
            _db = db;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductEdit newProduct)
    {
        ProductController product = new Product()
        {
            Name = newProduct.Name,
            Price = newProduct.Price,
            Quantity = newProduct.Quantity,
        };
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _db.Products.ToListAsync();
        return Ok(products);
    }
}