using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace backend_api_univalle.Models;

public partial class Departamento
{
    public Departamento()
    {
        Estado = true;
        FechaCreacion = DateTime.Now;
    }

    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
}
