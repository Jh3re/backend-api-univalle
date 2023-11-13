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
                lista = _dbcontext.Facultades.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        // Web
        [HttpGet]
        [Route("ListaActivos")]
        public IActionResult ListarActivos()
        {
            List<Facultad> lista = new List<Facultad>();
            try
            {
                lista = _dbcontext.Facultades.Where(f => f.Estado == true).ToList();

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
                oFacultad = _dbcontext.Facultades.Where(f => f.Id == idFacultad).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oFacultad });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oFacultad });
            }
        }
        // Admin Panel
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Facultad objeto)
        {
            try
            {
                _dbcontext.Facultades.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        // Admin Panel
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Facultad objeto)
        {
            Facultad oFacultad = _dbcontext.Facultades.Find(objeto.Id);

            if (oFacultad == null)
            {
                return BadRequest("Facultad no encontrada");
            }

            try
            {
                oFacultad.Titulo = objeto.Titulo is null ? oFacultad.Titulo : objeto.Titulo;
                oFacultad.Descripcion = objeto.Descripcion is null ? oFacultad.Descripcion : objeto.Descripcion;
                oFacultad.Imagen = objeto.Imagen is null ? oFacultad.Imagen : objeto.Imagen;
                oFacultad.Estado = objeto.Estado is null ? oFacultad.Estado : objeto.Estado;
                oFacultad.FechaCreacion = objeto.FechaCreacion is null ? oFacultad.FechaCreacion : objeto.FechaCreacion;

                _dbcontext.Facultades.Update(oFacultad);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        // Admin Panel
        [HttpPut]
        [Route("Eliminar/{idFacultad:int}")]
        public IActionResult Eliminar(int idFacultad)
        {
            Facultad oFacultad = _dbcontext.Facultades.Find(idFacultad);
            if (oFacultad == null)
            {
                return BadRequest("Facultad no encontrada");
            }
            try
            {
                oFacultad.Estado = false;

                _dbcontext.Facultades.Update(oFacultad);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
