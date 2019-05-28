using System;
using System.Collections.Generic;
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
    }
}
