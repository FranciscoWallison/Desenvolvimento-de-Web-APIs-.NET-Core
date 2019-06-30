using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Util;

namespace WebApplication.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Autenticacao AutenticacaoServocos;
        /*IHttpContextAccessor contextAccessor;

        public ClienteController(IHttpContextAccessor context)
        {
            //contextAccessor = context;
            //AutenticacaoServocos = new Autenticacao(context);
        }
        */

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

        // PUT api/atualizar/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody] ClienteModel dados)
        {
            ReturnAllServices returnAllServices = new ReturnAllServices();

            try
            {

                dados.Atualizar(id);
                returnAllServices.Result = true;
                returnAllServices.ErrorMessage = string.Empty;

            }
            catch (Exception e)
            {

                returnAllServices.Result = false;
                returnAllServices.ErrorMessage = "Erro registrar cliente: " + e.Message;
            }

            return returnAllServices;

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("deletar/{id}")]
        public ReturnAllServices Deletar(int id)
        {
            ReturnAllServices returnAllServices = new ReturnAllServices();
            
            try
            {
                //AutenticacaoServocos.Autenticar();
                new ClienteModel().deletar(id);
                returnAllServices.Result = true;
                returnAllServices.ErrorMessage = string.Empty;

            }
            catch (Exception e)
            {
                returnAllServices.Result = false;
                returnAllServices.ErrorMessage = "Erro deletar cliente: " + e.Message;
            }

            return returnAllServices;

        }
    }
}
