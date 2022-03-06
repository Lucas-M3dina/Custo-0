using Microsoft.AspNetCore.Mvc;
using Custo0.Domains;
using Custo0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private ClienteRepository _ClienteRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações no repositório
        /// </summary>
        public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        /// <summary>
        /// Lista todos os Cliente existentes
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_ClienteRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="IdCliente">ID do Cliente que será buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("IdCliente")]
        public IActionResult BuscarpPorId(int IdCliente)
        {
            Cliente ClienteBuscado = _ClienteRepository.BuscarPorId(IdCliente);

            if (ClienteBuscado == null)
            {
                return NotFound("O Cliente informado não existe no sistema!");
            }
            return Ok(ClienteBuscado);
        }

        /// <summary>
        /// Cadastra um Cliente
        /// </summary>
        /// <param name="NovoCliente">Usuario a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Cliente NovoCliente)
        {
            _ClienteRepository.Cadastrar(NovoCliente);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza umCliente existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("id")]
        public IActionResult Put(int id, Cliente ClienteAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _ClienteRepository.Atualizar(id, ClienteAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuario">id do Cliente a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("IdCliente")]
        public IActionResult Deletar(int idUsuario)
        {
            _ClienteRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
    }
}