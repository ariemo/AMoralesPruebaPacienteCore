using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoSangre
{
    public int IdTipoSangre { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();
}
