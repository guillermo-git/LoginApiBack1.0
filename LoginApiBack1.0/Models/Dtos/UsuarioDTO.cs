using SYSMEwebAPIback.Models;

namespace SYSMEwebAPIback.Models.Dtos
{
    public class UsuarioDTO
    {
        public string? Nombres { get; set; }

        public string? Cargo { get; set; }

        public string? User { get; set; }

        public string? Contra { get; set; }

        public string? Activo { get; set; }
        public string? Correo { get; set; }

        public int IdRol { get; set; }

    }
}
