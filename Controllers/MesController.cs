using meu_primiro_projeto_ef.DTO;
using meu_primiro_projeto_ef.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meu_primiro_projeto_ef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesController : ControllerBase
    {
        private readonly MesContext mesContext;

        //Construtor com parametro (Injetado)
        public MesController(MesContext mesContext)
        {
            this.mesContext = mesContext;
        }

        [HttpGet]
        public ActionResult<List<MesGetDTO>> Get()
        {
            //Alocando memória dos dados no contexto GET
            var listaMesModel = mesContext.Mes;
            List<MesGetDTO> listaGetDto = new List<MesGetDTO>();


            foreach (var item in listaMesModel)
            {
                var mesGetDTO = new MesGetDTO();
                mesGetDTO.Id = item.Id;
                mesGetDTO.Ano = item.Ano;
                mesGetDTO.Mes = item.Nome;

                listaGetDto.Add(mesGetDTO);
            }

            return Ok(listaGetDto);
        }

        /// <summary>
        /// http://localhost:5631/api/v1/banda/1984
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<MesCreateDTO> Post([FromBody] MesCreateDTO mesDto)
        {
            //MesDto > MesModel
            MesModel model = new MesModel();
            
            //Não preencher o id da model
            model.Nome = mesDto.DataHoraEvento.ToString("MMMM");
            model.Ano = mesDto.DataHoraEvento.Year;

            //Precisa add o mes model na propriedade DBSet<Mes>
            mesContext.Mes.Add(model);

            //Salva a informação no banco de dados
            mesContext.SaveChanges();

            mesDto.Codigo = model.Id;

            return Ok(mesDto);
        }

        [HttpPut]
        public ActionResult<MesUpdateDTO> Put([FromBody] MesUpdateDTO mesUpdateDTO)
        {

            //Buscar por id no banco de dados
            var mesModel = mesContext.Mes.Where(w => w.Id == mesUpdateDTO.Codigo).FirstOrDefault();
            
            //Verificar se não é null
            if (mesModel != null)
            {
                mesModel.Ano = mesUpdateDTO.Ano;

                //Se for diferente de null atualizar variavel (atribuir valores)
                //mesContext.Attach(mesModel);
                //mesContext.Mes.Update(mesModel);
                mesContext.Mes.Attach(mesModel);

                mesContext.SaveChanges();

                return Ok(mesUpdateDTO);
            }
            else
            {
                //se for null retorno um request de erro
                return BadRequest("Erro ao atualizar o registro");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var mesModel = mesContext.Mes.Find(id);

            //Verificar se o registro está diferente de null
            if (mesModel != null)
            {
                //Deletar o regitro no banco de dados
                //mesContext.Remove(mesModel);
                mesContext.Mes.Remove(mesModel);
                mesContext.SaveChanges();

                return Ok();
            }
            else
            {
                //se for null retorno um request de erro
                return BadRequest("Erro ao atualizar o registro");
            }
        }
    }
}
