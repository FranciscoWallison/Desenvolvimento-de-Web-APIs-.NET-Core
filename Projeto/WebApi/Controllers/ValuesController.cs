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
        public void gravar([FromBody] TodoApiModel todo)
        {
            //exemplo
            System.Diagnostics.Debug.WriteLine("Exemplo Post: " + todo.Id.ToString());
        }

        // PUT api/v1/webservece/cliente/{id}/editar
        [HttpPut("{id}")]
        [Route("cliente/{id}/editar")]
        public void editar(int id, [FromBody] TodoApiModel todo)
        {
            System.Diagnostics.Debug.WriteLine("Exemplo Put: " + id + " nome: " + todo.Name);
        }

        // DELETE api/v1/webservece/cliente/{id}/deletar
        [HttpDelete("{id}")]
        [Route("cliente/{id}/deletar")]
        public void deletar(int id)
        {
            System.Diagnostics.Debug.WriteLine("Exemplo Delete: " + id);
        }
    }
}
