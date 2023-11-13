using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_api_univalle.Models;
using System;

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

        // Admin Panel
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

        // Web
        [HttpGet]
        [Route("ListaPorFacultad/{idFacultad:int}")]
        public IActionResult ListarPorFacultad(int idFacultad)
        {

            List<Carrera> lista = new List<Carrera>();
            try
            {
                lista = _dbcontext.Carreras.Include(u => u.Ubicaciones).ThenInclude(d => d.oDepartamento).Where(f => f.FacultadId == idFacultad && f.Estado == true).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        // Admin Panel
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

        // Admin Panel
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Carrera objeto)
        {
            try
            {
                _dbcontext.Carreras.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});
            }
        }

        // Admin Panel
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Carrera objeto)
        {
            Carrera oCarrera = _dbcontext.Carreras.Find(objeto.Id);

            if (oCarrera == null)
            {
                return BadRequest("Carrera no encontrada");
            }

            try
            {
                oCarrera.Titulo = objeto.Titulo is null ? oCarrera.Titulo : objeto.Titulo ;
                oCarrera.Descripcion = objeto.Descripcion is null ? oCarrera.Descripcion : objeto.Descripcion;
                oCarrera.TituloOtorgado = objeto.TituloOtorgado is null ? oCarrera.TituloOtorgado : objeto.TituloOtorgado;
                oCarrera.Duracion = objeto.Duracion is null ? oCarrera.Duracion : objeto.Duracion;
                oCarrera.PlanDeEstudios = objeto.PlanDeEstudios is null ? oCarrera.PlanDeEstudios : objeto.PlanDeEstudios;
                oCarrera.Brochure = objeto.Brochure is null ? oCarrera.Brochure : objeto.Brochure;
                oCarrera.Imagen = objeto.Imagen is null ? oCarrera.Imagen : objeto.Imagen;
                oCarrera.FacultadId = objeto.FacultadId is null ? oCarrera.FacultadId : objeto.FacultadId;
                oCarrera.Estado = objeto.Estado is null ? oCarrera.Estado : objeto.Estado;
                oCarrera.FechaCreacion = objeto.FechaCreacion is null ? oCarrera.FechaCreacion : objeto.FechaCreacion;

                _dbcontext.Carreras.Update(oCarrera);
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
        [Route("Eliminar/{idCarrera:int}")]
        public IActionResult Eliminar(int idCarrera)
        {
            Carrera oCarrera = _dbcontext.Carreras.Find(idCarrera);
            if (oCarrera == null)
            {
                return BadRequest("Carrera no encontrada");
            }
            try
            {
                oCarrera.Estado = false;

                _dbcontext.Carreras.Update(oCarrera);
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
