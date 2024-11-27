using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;

using System.Linq.Expressions;
using LoginApiBack1._0.Models;

namespace SYSMEwebAPIback.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly  ScmerbdbContext scmerbdbContext;
        public usuariosController()
        {
            scmerbdbContext = new ScmerbdbContext();
        }


        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> Lista()
        {
            var lista =await scmerbdbContext.Usuarios.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }

    }
}
