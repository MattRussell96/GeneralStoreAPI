using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class ProductController : Controller   
    {
        private GeneralStoreDbContext _db;
        public ProductController(GeneralStoreDbContext db)
        {
            _db = db;
        }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductEdit newProduct)
    {
        Product product = new Product()
        {
            Name = newProduct.Name,
            Price = newProduct.Price,
            QuantityInStock = newProduct.Quantity,
        };
        _db.Product.Add(product);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _db.Product.ToListAsync();
        return Ok(products);
    }
    
    }
}