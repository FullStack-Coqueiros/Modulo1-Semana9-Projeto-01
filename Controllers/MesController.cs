using meu_primiro_projeto_ef.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meu_primiro_projeto_ef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
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
        public ActionResult Post([FromBody] MesModel mesModel)
        {
            return Ok(true);
        }

        [HttpPut]
        public ActionResult Put([FromBody] MesModel mesModel)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            return Ok();
        }
    }
}
