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
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository _produtoRepository { get; set; }
        private IEmpresaRepository _empresaRepository { get; set; }
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
            _empresaRepository = new EmpresaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepository.Listar());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorId(Id));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpGet("empresa/{Id}")]
        public IActionResult ProdutosEmpresa(int Id)
        {
            try
            {
                return Ok(_produtoRepository.ListarInstituicao(Id));
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto NovoProduto)
        {
            try
            {
                _produtoRepository.Cadastrar(NovoProduto);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _produtoRepository.Deletar(Id);
                return StatusCode(204);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Produto ProdutoAtualizado)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Empresa e = _empresaRepository.BuscarPorIdUser(idUsuario);

                if (ProdutoAtualizado.IdEmpresa == e.IdEmpresa)
                {
                    _produtoRepository.Atualizar(Id, ProdutoAtualizado);
                    return StatusCode(204);
                }
                return StatusCode(203);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }
    }
}