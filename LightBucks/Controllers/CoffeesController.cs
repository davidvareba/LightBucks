using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightBucks.Repositories;
using LightBucks.Models;

namespace LightBucks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepo;
        public CoffeesController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepo = coffeeRepository;
        }

        [HttpGet]

        public List<Coffee> GetAllCoffee()
        {
            return _coffeeRepo.GetAllCoffee();
        }

        [HttpGet("Coffee/{id}")]
        public ActionResult GetCoffeeById(int id)
        {
            Coffee coffee = _coffeeRepo.GetCoffeeById(id);
            if (coffee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(coffee);
            }
        }

        [HttpGet("Coffee/user/{uid}")]
        public ActionResult GetCoffeesByUserId(int uid)
        {
            List<Coffee> coffees = _coffeeRepo.GetCoffeesByUserId(uid);
            if (coffees == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(coffees);
            }
        }

        [HttpPost]

        public ActionResult AddCoffee(Coffee newCoffee)
        {
            if (newCoffee == null)
            {
                return NotFound();
                Console.WriteLine("Upload Failed");
            }
            else
            {
                _coffeeRepo.AddCoffee(newCoffee);
                return Ok(newCoffee);
            }

        }

        [HttpPatch("Coffee/id")]
        public ActionResult UpdateCoffee(int id, Coffee updateCoffee)
        {
            try
            {
                _coffeeRepo.UpdateCoffee(updateCoffee);
                return Ok(updateCoffee);
            }
            catch (Exception ex)
            {
                return BadRequest(updateCoffee);
            }
        }

        [HttpDelete("Coffee/{id}")]
        public ActionResult DeleteCoffee(int id)
        {
            try
            {
                _coffeeRepo.DeleteCoffee(id);
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
