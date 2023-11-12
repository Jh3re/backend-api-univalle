using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_api_univalle.Models;

namespace backend_api_univalle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        public readonly DbUnivalleV5Context _dbcontext;
        public CarreraController(DbUnivalleV5Context _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {
            List<Carrera> lista = new List<Carrera>();
            try
            {
                lista = _dbcontext.Carreras.Include(u => u.Ubicaciones).ThenInclude(d => d.oDepartamento).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        [HttpGet]
        [Route("Obtener/{idCarrera:int}")]
        public IActionResult Obtener(int idCarrera)
        {
            Carrera oCarrera = _dbcontext.Carreras.Find(idCarrera);
            if(oCarrera == null)
            {
                return BadRequest("Carrera no encontrada");
            }
            try
            {
                oCarrera = _dbcontext.Carreras.Include(u => u.Ubicaciones).ThenInclude(d => d.oDepartamento).Where(u => u.Id == idCarrera).FirstOrDefault(); 

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCarrera });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCarrera });
            }
        }
    }

}
