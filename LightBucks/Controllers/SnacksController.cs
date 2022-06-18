using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightBucks.Repositories;
using LightBucks.Models;

namespace LightBucks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly ISnackRepository _snackRepo;

        public SnacksController(ISnackRepository snackRepository)
        {
            _snackRepo = snackRepository;
        }

        [HttpGet]

        public List<Snack> GetAllSnack()
        {
            return _snackRepo.GetAllSnack();
        }

        [HttpGet("Snack/{id}")]
        public ActionResult GetSnackById(int id)
        {
            Snack snack = _snackRepo.GetSnackById(id);
            if (snack == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(snack);
            }
        }

        [HttpGet("Snack/user/{uid}")]
        public ActionResult GetSnackByUserId(int uid)
        {
            List<Snack> snacks = _snackRepo.GetSnackByUserId(uid);
            if (snacks == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(snacks);
            }
        }

        [HttpPost]

        public ActionResult AddSnack(Snack newSnack)
        {
            if (newSnack == null)
            {
                return NotFound();
                Console.WriteLine("Upload Failed");
            }
            else
            {
                _snackRepo.AddSnack(newSnack);
                return Ok(newSnack);
            }

        }

        [HttpPatch("Snack/id")]
        public ActionResult UpdateSnack(int id, Snack updateSnack)
        {
            try
            {
                _snackRepo.UpdateSnack(updateSnack);
                return Ok(updateSnack);
            }
            catch (Exception ex)
            {
                return BadRequest(updateSnack);
            }
        }

        [HttpDelete("Snack/{id}")]
        public ActionResult DeleteSnack(int id)
        {
            try
            {
                _snackRepo.DeleteSnack(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
