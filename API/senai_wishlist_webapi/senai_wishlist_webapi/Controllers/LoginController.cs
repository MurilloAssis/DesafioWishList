using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_wishlist_webapi.Domains;
using senai_wishlist_webapi.Interfaces;
using senai_wishlist_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_wishlist_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario Login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);
                if (usuarioBuscado != null)
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString())
                    };

                    var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senaiwishlistwebapi"));

                    var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                        issuer: "WishList.WebApi",
                        audience: "WishList.WebApi",
                        claims: Claims,
                        expires: DateTime.Now.AddMinutes(40),
                        signingCredentials: Creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }
                return NotFound("Email ou Senha Inválido!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
