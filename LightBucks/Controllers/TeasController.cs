using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightBucks.Repositories;
using LightBucks.Models;

namespace LightBucks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeasController : ControllerBase
    {
        private readonly ITeaRepository _teaRepo;

        public TeasController(ITeaRepository teaRepository)
        {
            _teaRepo = teaRepository;
        }

        [HttpGet]

        public List<Tea> GetAllTea()
        {
            return _teaRepo.GetAllTea();
        }

        [HttpGet("Tea/{id}")]
        public ActionResult GetTeaById(int id)
        {
            Tea tea = _teaRepo.GetTeaById(id);
            if (tea == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tea);
            }
        }

        [HttpGet("Tea/user/{uid}")]
        public ActionResult GetTeasByUserId(int uid)
        {
            List<Tea> teas = _teaRepo.GetTeasByUserId(uid);
            if (teas == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(teas);
            }
        }

        [HttpPost]

        public ActionResult AddTea(Tea newTea)
        {
            if (newTea == null)
            {
                return NotFound();
                Console.WriteLine("Upload Failed");
            }
            else
            {
                _teaRepo.AddTea(newTea);
                return Ok(newTea);
            }

        }

        [HttpPatch("Tea/id")]
        public ActionResult UpdateTea(int id, Tea updateTea)
        {
            try
            {
                _teaRepo.UpdateTea(updateTea);
                return Ok(updateTea);
            }
            catch (Exception ex)
            {
                return BadRequest(updateTea);
            }
        }

        [HttpDelete("Tea/{id}")]
        public ActionResult DeleteTea(int id)
        {
            try
            {
                _teaRepo.DeleteTea(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
