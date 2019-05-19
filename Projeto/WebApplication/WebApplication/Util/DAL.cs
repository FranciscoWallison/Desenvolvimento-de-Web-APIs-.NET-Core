using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "DBCLIENTE";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        //Executa: INSERT, UPTADE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        //Retorna Dados do Banco
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdapter.Fill(Dados);
            return Dados;
        }
    }

}
