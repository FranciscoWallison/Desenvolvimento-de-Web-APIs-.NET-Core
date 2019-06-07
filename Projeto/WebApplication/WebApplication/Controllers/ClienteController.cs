using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Util;

namespace WebApplication.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("listagem")]
        public List<ClienteModel> clientes()
        {
            return new ClienteModel().Listagem();
        }

        // GET api/values/5
        [HttpGet]
        [Route("value/{id}")]
        public ClienteModel cliente(int id)
        {
            return new ClienteModel().find(id);
        }

        // POST api/values
        [HttpPost]
        [Route("registrar")]
        public ReturnAllServices Registrar([FromBody] ClienteModel dados)
        {
            ReturnAllServices returnAllServices = new ReturnAllServices();

            try {

                dados.Registrar();
                returnAllServices.Result = true;
                returnAllServices.ErrorMessage = string.Empty;

            } catch (Exception e) {

                returnAllServices.Result = false;
                returnAllServices.ErrorMessage = "Erro registrar cliente: " + e.Message;
            }

            return returnAllServices;
       
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
