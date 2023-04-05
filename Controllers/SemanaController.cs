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
    public class SemanaController : ControllerBase
    {

        private readonly MeuBancoDadosContext meuBancoDadosContext;


        //Construtor com parametro (Injetado)
        public SemanaController(MeuBancoDadosContext  meuBancoDadosContext)
        {
            this.meuBancoDadosContext = meuBancoDadosContext; 
        }

        [HttpPost]
        public ActionResult<SemanaCreateDTO> Post([FromBody] SemanaCreateDTO semanaDTO)
        {

            //Instanciar minha semanaModel.cs 
            //Passar meus parametros para a instancia criada no método post
            SemanaModel semanaModel = new SemanaModel();
            semanaModel.Dia = semanaDTO.Dia;
            semanaModel.MesId = semanaDTO.MesId;
            semanaModel.Observacao = semanaDTO.Observacao;

            //Verificar se existe o MES no banco de dados
            var mesModel = meuBancoDadosContext.Mes.Find(semanaDTO.MesId);

            if(mesModel != null){

                //Add na lista do DBSet Semana
                meuBancoDadosContext.Semana.Add(semanaModel);

                //Salvar no banco de dados
                meuBancoDadosContext.SaveChanges();

                semanaDTO.Id = semanaModel.Id;
                return Ok(semanaDTO);
            }
            else{
                return BadRequest("Erro ao salvar a semana no banco de dados");
            }    
        }
    }
}