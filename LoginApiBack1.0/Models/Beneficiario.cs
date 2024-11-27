using System;
using System.Collections.Generic;

namespace LoginApiBack1._0.Models;

public partial class Beneficiario
{
    public int IdBeneficiario { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Edad { get; set; }

    public string? Dui { get; set; }

    public float? Porcentaje { get; set; }
}
