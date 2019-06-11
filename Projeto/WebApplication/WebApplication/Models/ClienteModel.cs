using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Util;

namespace WebApplication.Models
{
    public class ClienteModel
    {
        //nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep,
        //logradouro, numero, bairro, complemento, cidade, uf
        public int Id { get; set;}
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

        public void Registrar()
        {
            DAL objDAL = new DAL();

            string sql = "INSERT INTO cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                $"VALUES('{Nome}', '{DateTime.Parse(Data_Cadastro).ToString("yyy/MM/dd")}', '{Cpf_Cnpj}', '{DateTime.Parse(Data_Nascimento).ToString("yyy/MM/dd")}', '{Tipo}', " +
                $"'{Telefone}', '{Email}', '{Cep}','{Logradouro}', '{Numero}', '{Bairro}', '{Complemento}', '{Cidade}', '{Uf}')";

            objDAL.ExecutarComandoSQL(sql);


        }

        public void Atualizar(int idCliente )
        {
            DAL objDAL = new DAL();

            string sql = "UPDATE cliente SET " +
                $"nome = '{Nome}' ," +
                $"data_cadastro = '{DateTime.Parse(Data_Cadastro).ToString("yyy/MM/dd")}' ," +
                $"cpf_cnpj = '{Cpf_Cnpj}' ," +
                $"data_nascimento = '{DateTime.Parse(Data_Nascimento).ToString("yyy/MM/dd")}' ," +
                $"tipo = '{Tipo}' ," +
                $"telefone = '{Telefone}' ," +
                $"email = '{Email}' ," +
                $"cep = '{Cep}' ," +
                $"logradouro = '{Logradouro}' ," +
                $"numero = '{Numero}' ," +
                $"bairro = '{Bairro}' ," +
                $"complemento = '{Complemento}' ," +
                $"cidade = '{Cidade}' ," +
                $"uf = '{Uf}' WHERE id = {idCliente}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public List<ClienteModel> Listagem()
        {

            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = "SELECT * FROM cliente ORDER BY nome ASC";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {

                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy"),
                    Cpf_Cnpj = dados.Rows[i]["Cpf_Cnpj"].ToString(),
                    Data_Nascimento = DateTime.Parse(dados.Rows[i]["Data_Nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Tipo = dados.Rows[i]["Tipo"].ToString(),
                    Telefone = dados.Rows[i]["Telefone"].ToString(),
                    Email = dados.Rows[i]["Email"].ToString(),
                    Cep = dados.Rows[i]["CeP"].ToString(),
                    Logradouro = dados.Rows[i]["Logradouro"].ToString(),
                    Numero = dados.Rows[i]["Numero"].ToString(),
                    Bairro = dados.Rows[i]["Bairro"].ToString(),
                    Cidade = dados.Rows[i]["Cidade"].ToString(),
                    Uf = dados.Rows[i]["Uf"].ToString()
                };
                lista.Add(item);
            }

            return lista;

        }

        public ClienteModel find(int id)
        {
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM cliente WHERE id = '{id}'";
            DataTable dados = objDAL.RetornarDataTable(sql);

            if (dados.Rows.Count == 0)
                return new ClienteModel();
         
            item = new ClienteModel()
            {

                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Cpf_Cnpj = dados.Rows[0]["Cpf_Cnpj"].ToString(),
                Data_Nascimento = DateTime.Parse(dados.Rows[0]["Data_Nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Tipo = dados.Rows[0]["Tipo"].ToString(),
                Telefone = dados.Rows[0]["Telefone"].ToString(),
                Email = dados.Rows[0]["Email"].ToString(),
                Cep = dados.Rows[0]["CeP"].ToString(),
                Logradouro = dados.Rows[0]["Logradouro"].ToString(),
                Numero = dados.Rows[0]["Numero"].ToString(),
                Bairro = dados.Rows[0]["Bairro"].ToString(),
                Cidade = dados.Rows[0]["Cidade"].ToString(),
                Uf = dados.Rows[0]["Uf"].ToString()
            };
         
            return item;
        }


        public void deletar(int id)
        {

            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM cliente WHERE id = '{id}'";
            DataTable dados = objDAL.RetornarDataTable(sql);

            if (dados.Rows.Count != 0) {
                string sqlDelete = $"DELETE FROM cliente WHERE id = '{id}'";
                DataTable dadoDelte = objDAL.RetornarDataTable(sqlDelete);
            }
           
        }
    }
    
}
