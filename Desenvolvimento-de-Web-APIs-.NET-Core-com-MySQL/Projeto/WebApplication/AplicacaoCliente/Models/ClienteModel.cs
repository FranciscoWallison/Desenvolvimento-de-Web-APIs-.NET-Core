using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCliente.Models
{
    public class ClienteModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }


        public List<ClienteModel> ListarTodosClientes()
        {

            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = Util.WebAPI.RequestGET("listagem", string.Empty);

            retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClienteModel>>(json);

            return retorno;
        }

        public void Inserir()
        {

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            if (Id == 0)
            {
                string json = Util.WebAPI.RequestPOST("registrar", jsonData);
            }
            else {
                string json = Util.WebAPI.RequestPut("atualizar/" + Id, jsonData);
            }

        }

        public void Deletar(int id)
        {            
            string json = Util.WebAPI.RequestDELETE("Deletar/", id.ToString());

        }

        

        public ClienteModel Carregar(int? id) {
            ClienteModel retorno = new ClienteModel();
            string json = Util.WebAPI.RequestGET("value/", id.ToString());

            retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;

        }
    }
}
