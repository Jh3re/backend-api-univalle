using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_api_univalle.Models;

namespace backend_api_univalle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        public readonly DbUnivalleV5Context _dbcontext;
        public DepartamentoController(DbUnivalleV5Context _context)
        {
            _dbcontext = _context;
        }
        // Admin Panel
        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {
            List<Departamento> lista = new List<Departamento>();
            try
            {
                lista = _dbcontext.Departamentos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        // Admin Panel
        [HttpGet]
        [Route("ListaActivos")]
        public IActionResult ListarActivos()
        {
            List<Departamento> lista = new List<Departamento>();
            try
            {
                lista = _dbcontext.Departamentos.Where(d => d.Estado == true).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        [HttpGet]
        [Route("Obtener/{idDepartamento:int}")]
        public IActionResult Obtener(int idDepartamento)
        {
            Departamento oDepartamento = _dbcontext.Departamentos.Find(idDepartamento);
            if (oDepartamento == null)
            {
                return BadRequest("Departamento no encontrado");
            }
            try
            {
                oDepartamento = _dbcontext.Departamentos.Where(d => d.Id == idDepartamento).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oDepartamento });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oDepartamento });
            }
        }
        // Admin Panel
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Departamento objeto)
        {
            try
            {
                _dbcontext.Departamentos.Add(objeto);
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
        public IActionResult Editar([FromBody] Departamento objeto)
        {
            Departamento oDepartamento = _dbcontext.Departamentos.Find(objeto.Id);

            if (oDepartamento == null)
            {
                return BadRequest("Departamento no encontrado");
            }

            try
            {
                oDepartamento.Nombre = objeto.Nombre is null ? oDepartamento.Nombre : objeto.Nombre;
                oDepartamento.Estado = objeto.Estado is null ? oDepartamento.Estado : objeto.Estado;
                oDepartamento.FechaCreacion = objeto.FechaCreacion is null ? oDepartamento.FechaCreacion : objeto.FechaCreacion;

                _dbcontext.Departamentos.Update(oDepartamento);
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
        [Route("Eliminar/{idDepartamento:int}")]
        public IActionResult Eliminar(int idDepartamento)
        {
            Departamento oDepartamento = _dbcontext.Departamentos.Find(idDepartamento);

            if (oDepartamento == null)
            {
                return BadRequest("Carrera no encontrada");
            }
            try
            {
                oDepartamento.Estado = false;

                _dbcontext.Departamentos.Update(oDepartamento);
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
