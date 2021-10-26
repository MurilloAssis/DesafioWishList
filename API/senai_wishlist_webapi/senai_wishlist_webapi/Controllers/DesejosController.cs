using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_wishlist_webapi.Domains;
using senai_wishlist_webapi.Interfaces;
using senai_wishlist_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webapi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        
        [HttpGet]
        public IActionResult Listar()
        {
            List<Desejo> lista = _desejoRepository.listarDesejos();

            return StatusCode(201, lista);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Desejo novoDesejo)
        {
            novoDesejo.IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            _desejoRepository.cadastrarDesejos(novoDesejo);

            return StatusCode(201);
        }
    }
}
