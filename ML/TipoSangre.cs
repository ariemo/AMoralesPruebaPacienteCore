using System;
using System.Collections.Generic;

namespace ML;

public  class TipoSangre
{
    public int? IdTipoSangre { get; set; }

    public string? Nombre { get; set; }

    public ML.Paciente Paciente { get; set; }

    
}
