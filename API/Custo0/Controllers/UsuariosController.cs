using Custo0.Domains;
using Custo0.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository contexto)
        {
            _usuarioRepository = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Usuario user)
        {
            try
            {
                _usuarioRepository.Cadastrar(user);

                return Created("Usuario Cadastrado", new { id = user.IdUsuario });
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
