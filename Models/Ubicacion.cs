using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace backend_api_univalle.Models;

public partial class Ubicacion
{
    public int Id { get; set; }

    public int? CarreraId { get; set; }

    public int? DepartamentoId { get; set; }

    [JsonIgnore]
    public virtual Carrera? oCarrera { get; set; }

    public virtual Departamento? oDepartamento { get; set; }
}
