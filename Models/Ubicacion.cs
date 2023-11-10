using System;
using System.Collections.Generic;

namespace backend_api_univalle.Models;

public partial class Ubicacion
{
    public int Id { get; set; }

    public int? CarreraId { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Carrera? Carrera { get; set; }

    public virtual Departamento? Departamento { get; set; }
}
