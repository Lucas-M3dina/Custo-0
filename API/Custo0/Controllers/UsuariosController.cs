using Custo0.Domains;
using Custo0.Interfaces;
using Custo0.Repositories;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        private IClienteRepository _clienteRepository { get; set; }
        private IEmpresaRepository _empresaRepository { get; set; }


        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
            _clienteRepository = new ClienteRepository();
            _empresaRepository = new EmpresaRepository();
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

                
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
