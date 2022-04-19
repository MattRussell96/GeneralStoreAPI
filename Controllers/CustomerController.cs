using System.Threading.Tasks;
using GeneralStoreAPI;
using Microsoft.AspNetCore.Mvc;

namespace GeneralStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private GeneralStoreDbContext _db;
        public CustomerController(GeneralStoreDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerEdit newCustomer)
        {
            Customer customer = new Customer()
            {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
