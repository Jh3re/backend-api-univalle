using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace backend_api_univalle.Models;

public partial class Carrera
{
    public Carrera()
    {
        Estado = true; 
        FechaCreacion = DateTime.Now; 
    }

    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? TituloOtorgado { get; set; }

    public int? Duracion { get; set; }

    public string? PlanDeEstudios { get; set; }

    public string? Brochure { get; set; }

    public string? Imagen { get; set; }

    public int? FacultadId { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    [JsonIgnore]
    public virtual Facultad? oFacultad { get; set; }

    public virtual ICollection<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
}
