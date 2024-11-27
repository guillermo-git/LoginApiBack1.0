using System;
using System.Collections.Generic;

namespace LoginApiBack1._0.Models;

public partial class Accionistum
{
    public int IdAccionista { get; set; }

    public string? Nombre { get; set; }

    public string? TipoPersona { get; set; }

    public float? Porcentaje { get; set; }

    public string? Beneficiarios { get; set; }

    public byte[]? Direccion { get; set; }

    public string? Nit { get; set; }

    public string? NCR { get; set; }
}
