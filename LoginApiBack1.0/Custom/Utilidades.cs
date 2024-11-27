
using LoginApiBack1._0.Models;
using Microsoft.IdentityModel.Tokens;
using SYSMEwebAPIback.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SYSMEwebAPIback.Custom
{
    public class Utilidades
    {

        private  IConfiguration _config;


        public Utilidades(IConfiguration configuration)
        {
            _config= configuration;


        }

        public string encriptSHA256(string texto)
        {
            using(SHA256 sHA256=SHA256.Create())
            {
                byte[] bytes=sHA256.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder1=new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder1.Append(bytes[i].ToString("x2"));

                }

                return builder1.ToString();



            }



        }
        public string generarJWT(Usuario modelo)
        {
            var userClainms = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.IdUser.ToString()),
                new Claim(ClaimTypes.NameIdentifier, modelo.IdRol.ToString()),
                new Claim(ClaimTypes.NameIdentifier, modelo.Nombres),
                 new Claim(ClaimTypes.NameIdentifier, modelo.Correo)



            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
            var credentials= new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                claims:userClainms,
                expires:DateTime.UtcNow.AddMinutes(10),
                signingCredentials:credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
