using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/v1/webservece")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/v1/webservece/clientes
        [HttpGet]
        [Route("clientes")]
        public ActionResult<IEnumerable<string>> clientes()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/v1/webservece/5/cliente
        [HttpGet("{id}")]
        [Route("{id}/cliente")]
        public ActionResult<string> cliente(int id)
        {
            return id.ToString();
        }

        // POST api/v1/webservece/cliente/gravar
        [HttpPost]
        [Route("cliente/gravar")]
        public ActionResult<string> gravar([FromBody] TodoApiModel todo)
        {
            //exemplo
            return "Exemplo Post: Id: " + 20 + " Nome: " + todo.Name.ToString();
        }

        // PUT api/v1/webservece/cliente/{id}/editar
        [HttpPut("{id}")]
        [Route("cliente/{id}/editar")]
        public ActionResult<string> editar(int id, [FromBody] TodoApiModel todo)
        {
            return "Exemplo Put: Id: " + id + " Nome: " + todo.Name;
        }

        // DELETE api/v1/webservece/cliente/{id}/deletar
        [HttpDelete("{id}")]
        [Route("cliente/{id}/deletar")]
        public ActionResult<string> deletar(int id)
        {
            return "Exemplo Delete: " + id;
        }
    }
}
