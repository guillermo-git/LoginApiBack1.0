using System;
using System.Collections.Generic;

namespace LoginApiBack1._0.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Nombres { get; set; }

    public string? Cargo { get; set; }

    public string? Contra { get; set; }

    public string? Activo { get; set; }

    public int IdRol { get; set; }

    public string? Correo { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
