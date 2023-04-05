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
        private readonly MeuBancoDadosContext meuBancoDadosContext;

        //Construtor com parametro (Injetado)
        public MesController(MeuBancoDadosContext meuBancoDadosContext)
        {
            this.meuBancoDadosContext = meuBancoDadosContext;
        }

        [HttpGet]
        public ActionResult<List<MesGetDTO>> Get()
        {
            //Alocando mem�ria dos dados no contexto GET
            var listaMesModel = meuBancoDadosContext.Mes;
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
        public ActionResult<MesGetDTO> Get([FromRoute] int id)
        {
            //Buscar o registro no banco de dados por >>>ID<<<
            var mesModel = meuBancoDadosContext.Mes.Find(id);
            //var mesModel = meuBancoDadosContext.Mes.Where(w => w.Id == id).FirstOrDefault();

            if (mesModel == null)
            {
                return BadRequest("Dados n�o encontrados no banco de dados");
            }

            //Modificar de mesModel para MesGetDTO
            //dto � minha mesGetDTO
            MesGetDTO mesGetDTO = new MesGetDTO();
            mesGetDTO.Id = mesModel.Id;
            mesGetDTO.Ano = mesModel.Ano;
            mesGetDTO.Mes = mesModel.Nome;

            return Ok(mesGetDTO);
        }

        [HttpPost]
        public ActionResult<MesCreateDTO> Post([FromBody] MesCreateDTO mesDto)
        {
            //MesDto > MesModel
            MesModel model = new MesModel();
            
            //N�o preencher o id da model
            model.Nome = mesDto.DataHoraEvento.ToString("MMMM");
            model.Ano = mesDto.DataHoraEvento.Year;

            //Precisa add o mes model na propriedade DBSet<Mes>
            meuBancoDadosContext.Mes.Add(model);

            //Salva a informa��o no banco de dados
            meuBancoDadosContext.SaveChanges();

            mesDto.Codigo = model.Id;

            return Ok(mesDto);
        }

        [HttpPut]
        public ActionResult<MesUpdateDTO> Put([FromBody] MesUpdateDTO mesUpdateDTO)
        {

            //Buscar por id no banco de dados
            var mesModel = meuBancoDadosContext.Mes.Where(w => w.Id == mesUpdateDTO.Codigo).FirstOrDefault();
            
            //Verificar se n�o � null
            if (mesModel != null)
            {
                mesModel.Ano = mesUpdateDTO.Ano;

                //Se for diferente de null atualizar variavel (atribuir valores)
                //MeuBancoDadosContext.Attach(mesModel);
                //MeuBancoDadosContext.Mes.Update(mesModel);
                meuBancoDadosContext.Mes.Attach(mesModel);

                meuBancoDadosContext.SaveChanges();

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
            var mesModel = meuBancoDadosContext.Mes.Find(id);

            //Verificar se o registro est� diferente de null
            if (mesModel != null)
            {
                //Deletar o regitro no banco de dados
                //meuBancoDadosContext.Remove(mesModel);
                meuBancoDadosContext.Mes.Remove(mesModel);
                meuBancoDadosContext.SaveChanges();

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
