using System;
using System.Collections.Generic;

namespace backend_api_univalle.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();
}
