using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using SYSMEwebAPIback.Custom;
using SYSMEwebAPIback.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using SYSMEwebAPIback.Models;
using System.Linq.Expressions;
using LoginApiBack1._0.Models;

namespace SYGMEwebAPIback.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly ScmerbdbContext _scmerbdbContext;
        private readonly Utilidades _utilidades;


        public AccesoController(ScmerbdbContext scmerbdbContext, Utilidades utilidades)
        {
            _scmerbdbContext = scmerbdbContext;
            _utilidades = utilidades;

        }

        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Registro(UsuarioDTO obj)
        {
            var modeloUsuario = new Usuario
            {
                Nombres = obj.Nombres,
                Cargo = obj.Cargo,
                Contra = _utilidades.encriptSHA256(obj.Contra),
                Activo = obj.Activo,
                IdRol = obj.IdRol,
                Correo = obj.Correo
            };
            await _scmerbdbContext.Usuarios.AddAsync(modeloUsuario);
            await _scmerbdbContext.SaveChangesAsync();

            if (modeloUsuario.IdUser != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucces = true });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucces = false });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(LoginDTO objeto)

        {
            var usuarioEcontrado = await _scmerbdbContext.Usuarios.Where(u => u.Correo == objeto.Email &&
            u.Contra == _utilidades.encriptSHA256(objeto.Password)).FirstOrDefaultAsync();

            if (usuarioEcontrado == null) { 
                return StatusCode(StatusCodes.Status200OK,new { isSuccess=false, token=""});

            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEcontrado) });

            }

        }

    }
}
