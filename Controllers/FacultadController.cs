using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_api_univalle.Models;

namespace backend_api_univalle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadController : ControllerBase
    {
        public readonly DbUnivalleV5Context _dbcontext;
        public FacultadController(DbUnivalleV5Context _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {
            List<Facultad> lista = new List<Facultad>();
            try
            {
                lista = _dbcontext.Facultades.Include(c => c.Carreras).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idFacultad:int}")]
        public IActionResult Obtener(int idFacultad)
        {
            Facultad oFacultad = _dbcontext.Facultades.Find(idFacultad);
            if (oFacultad == null)
            {
                return BadRequest("Facultad no encontrada");
            }
            try
            {
                oFacultad = _dbcontext.Facultades.Include(c => c.Carreras).Where(f => f.Id == idFacultad).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oFacultad });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oFacultad });
            }
        }
    }
}
