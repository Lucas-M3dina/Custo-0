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
    public class EstadosController : ControllerBase
    {
        private IEstadoRepository _estadoRepository { get; set; }


        public EstadosController()
        {
            _estadoRepository = new EstadoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estadoRepository.Listar());
        }



    }
}
