using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meu_primiro_projeto_ef.DTO;
using meu_primiro_projeto_ef.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meu_primiro_projeto_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemanaController : ControllerBase
    {

        private readonly MeuBancoDadosContext meuBancoDadosContext;


        //Construtor com parametro (Injetado)
        public SemanaController(MeuBancoDadosContext meuBancoDadosContext)
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

            if (mesModel != null)
            {

                //Add na lista do DBSet Semana
                meuBancoDadosContext.Semana.Add(semanaModel);

                //Salvar no banco de dados
                meuBancoDadosContext.SaveChanges();

                semanaDTO.Id = semanaModel.Id;
                return Ok(semanaDTO);
            }
            else
            {
                return BadRequest("Erro ao salvar a semana no banco de dados");
            }
        }

        //Devolve todos os registro
        [HttpGet]
        public ActionResult<List<MesSemanaGetDTO>> Get()
        {

            List<MesSemanaGetDTO> lista = new List<MesSemanaGetDTO>();

            //SELECT Mes.*, Semana.*
            //FROM Mes
            //INNER JOIN Semana ON Semana.MesId = Mes.Id
            IQueryable<MesModel> mesesSemanasInnerJoin = meuBancoDadosContext
                                                        .Mes
                                                        .Include(c => c.SemanaModels);

            foreach (var mes in mesesSemanasInnerJoin)
            {
                MesSemanaGetDTO mesSemanaDto = new MesSemanaGetDTO()
                {
                    IdMes = mes.Id,
                    Mes = mes.Nome,
                    SemanaGetDTOs = new List<SemanaGetDTO>()
                };

                foreach (var semana in mes.SemanaModels)
                {
                    SemanaGetDTO semanaGetDTOUm = new SemanaGetDTO();
                    semanaGetDTOUm.IdSemana = semana.Id;
                    semanaGetDTOUm.Dia = semana.Dia;
                    semanaGetDTOUm.Observacao = semana.Observacao;

                    mesSemanaDto.SemanaGetDTOs.Add(semanaGetDTOUm);
                }

                lista.Add(mesSemanaDto);
            }

            return Ok(lista);
        }

        //Devolve todos os registro
        [HttpGet("{id}")]
        public ActionResult<MesSemanaGetDTO> Get([FromRoute] int id)
        {
            //SELECT Mes.*, Semana.*
            //FROM Mes
            //INNER JOIN Semana ON Semana.MesId = Mes.Id
            //WHERE Semana.Id = id
            SemanaModel? mesesSemanasInnerJoin = meuBancoDadosContext
                                                        .Semana
                                                        .Include(c => c.Mes)
                                                        .Where(w => w.Id == id)
                                                        .FirstOrDefault();
            if (mesesSemanasInnerJoin == null)
            {
                return BadRequest("Registro não encontrado");
            }

            MesSemanaGetDTO mesSemanaDto = new MesSemanaGetDTO()
            {
                IdMes = mesesSemanasInnerJoin.MesId,
                Mes = mesesSemanasInnerJoin.Mes.Nome,
                SemanaGetDto = new SemanaGetDTO()
            };

            //Classe.Propriedade.Atributos = Valor.Id
            mesSemanaDto.SemanaGetDto.IdSemana = mesesSemanasInnerJoin.Id;
            mesSemanaDto.SemanaGetDto.Dia = mesesSemanasInnerJoin.Dia;
            mesSemanaDto.SemanaGetDto.Observacao = mesesSemanasInnerJoin.Observacao;

            return Ok(mesSemanaDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var semanaModel = meuBancoDadosContext.Semana.Find(id);

            //Verificar se o registro est� diferente de null
            if (semanaModel != null)
            {
                //Deletar o regitro no banco de dados
                //meuBancoDadosContext.Remove(mesModel);
                meuBancoDadosContext.Semana.Remove(semanaModel);
                meuBancoDadosContext.SaveChanges();

                return Ok();
            }
            else
            {
                //se for null retorno um request de erro
                return BadRequest("Erro ao atualizar o registro");
            }
        }

        [HttpPatch]
        public ActionResult<SemanaUpdateDTO> Patch(SemanaUpdateDTO semanaUpdateDTO)
        {
            //Instanciar minha semanaModel.cs 
            //Passar meus parametros para a instancia criada no método post
            SemanaModel? semanaModel = meuBancoDadosContext.Semana.Find(semanaUpdateDTO.Id);

            if (semanaModel == null)
            {
                //se for null retorno um request de erro
                return BadRequest("Erro ao atualizar o registro");
            }
            
            //Verificar se existe o MES no banco de dados
            var mesModel = meuBancoDadosContext.Mes.Find(semanaUpdateDTO.MesId);

            if (mesModel != null)
            {
                semanaModel.Dia = semanaUpdateDTO.Dia;
                semanaModel.MesId = semanaUpdateDTO.MesId;

                //Add na lista do DBSet Semana
                meuBancoDadosContext.Semana.Attach(semanaModel);

                //Salvar no banco de dados
                meuBancoDadosContext.SaveChanges();

                semanaModel.Id = semanaModel.Id;
                return Ok(semanaUpdateDTO);
            }
            else
            {
                return BadRequest("Erro ao salvar a semana no banco de dados");
            }
        }
    }
}