using System;
using System.Collections.Generic;

namespace LoginApiBack1._0.Models;

public partial class Rol
{
    public int Idrol { get; set; }

    public string? Descripcion { get; set; }

    public string? FechaRegistro { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
