using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Util;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DAL objDAL = new DAL();

            /*
            string sql = "INSERT INTO cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                "VALUES('Wallison', '2019/05/17', '02112323423', '1995/05/17', 'F', '85989129087', 'franciscowallison@gmail.com', '6000', 'Rua Emiliano', '104', 'Passare', '', 'Fortaleza', 'CE')";

            objDAL.ExecutarComandoSQL(sql);
            */
            

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM cliente WHERE id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);
            
            return dados.Rows[0]["nome"].ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
