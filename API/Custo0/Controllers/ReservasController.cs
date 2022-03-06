using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Custo0.Domains;
using Custo0.Interfaces;
using Custo0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Custo0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IReservaRepository _reservaRepository { get; set; }
        private IClienteRepository _clienteRepository { get; set; }
        private IEmpresaRepository _empresaRepository { get; set; }
        private IProdutoRepository _produtoRepository { get; set; }
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public ReservasController()
        {
            _reservaRepository = new ReservaRepository();
            _produtoRepository = new ProdutoRepository();
            _clienteRepository = new ClienteRepository();
            _empresaRepository = new EmpresaRepository();
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Lista todas as Reservas existentes
        /// </summary>
        /// <returns>Uma lista de Reservas</returns>
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_reservaRepository.Listar());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [HttpGet("cliente")]
        public IActionResult ListaDoCliente()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Cliente c = _clienteRepository.BuscarPorIdUser(idUsuario);

                return Ok(_reservaRepository.ListarCliente(c.IdCliente));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [HttpGet("empresa")]
        public IActionResult ListaDaEmpresa()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Empresa e = _empresaRepository.BuscarPorIdUser(idUsuario);

                return Ok(_reservaRepository.ListarEmpresa(e.IdEmpresa));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpGet("empresa/pendente")]
        public IActionResult PendenteDaEmpresa()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Empresa e = _empresaRepository.BuscarPorIdUser(idUsuario);

                return Ok(_reservaRepository.ListarPendentes(e.IdEmpresa));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        /// <summary>
        /// Cadastra uma Reserva
        /// </summary>
        /// <param name="NovaReserva">Reserva a ser cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult CriarReserva(Reserva NovaReserva)
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            Usuario u = _usuarioRepository.BuscarPorId(idUsuario);
            Produto p = _produtoRepository.BuscarPorId(NovaReserva.IdProduto);
            Cliente c = _clienteRepository.BuscarPorIdUser(idUsuario);

            NovaReserva.IdCliente = c.IdCliente;
            NovaReserva.IdSituacao = 1;
            NovaReserva.Preco = p.Preco;
            NovaReserva.IdEmpresa = p.IdEmpresa;
            NovaReserva.DataSolicitacao = DateTime.Now;

            _reservaRepository.Criar(NovaReserva);

            return StatusCode(201);
        }

        [Authorize(Roles = "3")]
        [HttpPost("doacao")]
        public IActionResult Doacao(Reserva NovaReserva)
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            Usuario u = _usuarioRepository.BuscarPorId(idUsuario);
            Produto p = _produtoRepository.BuscarPorId(NovaReserva.IdProduto);
            Cliente c = _clienteRepository.BuscarPorIdUser(idUsuario);

            NovaReserva.IdCliente = c.IdCliente;
            NovaReserva.IdSituacao = 1;
            NovaReserva.Preco = 0;
            NovaReserva.IdEmpresa = p.IdEmpresa;
            NovaReserva.DataSolicitacao = DateTime.Now;

            _reservaRepository.Criar(NovaReserva);

            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Reserva ReservaAtualizado)
        {
            try
            {
                _reservaRepository.Editar(Id, ReservaAtualizado);
                return StatusCode(204);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        /// <summary>
        /// Deleta um Reserva
        /// </summary>
        /// <param name="idReserva">id do Usuário a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("IdReserva")]
        public IActionResult Deletar(int idReserva)
        {
            _reservaRepository.Deletar(idReserva);

            return StatusCode(204);
        }
    }
}