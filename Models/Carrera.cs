using System;
using System.Collections.Generic;

namespace backend_api_univalle.Models;

public partial class Carrera
{
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

    public virtual Facultad? Facultad { get; set; }

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();
}
