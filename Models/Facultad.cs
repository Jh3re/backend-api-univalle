﻿using System;
using System.Collections.Generic;

namespace backend_api_univalle.Models;

public partial class Facultad
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Carrera> Carreras { get; set; } = new List<Carrera>();
}