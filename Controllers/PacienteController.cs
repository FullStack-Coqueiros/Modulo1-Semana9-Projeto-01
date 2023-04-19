using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meu_primiro_projeto_ef.DTO;
using meu_primiro_projeto_ef.Model;
using Microsoft.AspNetCore.Mvc;

namespace meu_primiro_projeto_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly MeuBancoDadosContext meuBancoDadosContext;

        public PacienteController(MeuBancoDadosContext meuBancoDadosContext) 
        {
            this.meuBancoDadosContext = meuBancoDadosContext;
        }


        [HttpPost]
        public ActionResult<MesCreateDTO> Post([FromBody] MesCreateDTO mesCreateDTO)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<PacienteGetDto> Get()
        {
            PacienteGetDto pacienteGetDto  = new PacienteGetDto();
            pacienteGetDto.Id = 1;
            pacienteGetDto.Cpf = "123456789";

            return Ok(pacienteGetDto);
        }
    }
}