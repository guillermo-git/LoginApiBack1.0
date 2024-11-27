using System;
using System.Collections.Generic;

namespace LoginApiBack1._0.Models;

public partial class Certificado
{
    public int? IdCertifcado { get; set; }

    public string? NumCuenta { get; set; }

    public int IdAccionista { get; set; }

    public float? Monto { get; set; }

    public string? FechaApertura { get; set; }

    public string? FechaVencimiento { get; set; }

    public float? TInteres { get; set; }

    public int? Plazo { get; set; }

    public string? TipoPago { get; set; }

    public string? FormaPago { get; set; }

    public int IdRepreLegal { get; set; }

    public int IdBeneficiario { get; set; }

    public virtual Accionistum IdAccionistaNavigation { get; set; } = null!;

    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;

    public virtual RepreLegal IdRepreLegalNavigation { get; set; } = null!;
}
