﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        [Route("Obtener/{idDepartamento:int}")]
        public IActionResult Obtener(int idDepartamento)
        {
            Departamento oDepartamento = _dbcontext.Departamentos.Find(idDepartamento);
            if (oDepartamento == null)
            {
                return BadRequest("Departamento no encontrada");
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
    }
}
