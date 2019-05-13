using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsumindoWebApi
{
    class Program
    {
        static void Main(string[] args)
        {

            bool endApp = false;
            
            while (!endApp)
            {

                Console.WriteLine("Escolha o tipo de requisição: ");
                Console.WriteLine("\t1 - Lista de usuários v1 (Teste). ");
                Console.WriteLine("\t2 - Selecionar cliente cadastrado v1 (Teste). ");
                Console.WriteLine("\t3 - Gravar cliente v1 (Teste). ");
                Console.WriteLine("\t4 - Editar cliente v1 (Teste).");
                Console.WriteLine("\t5 - Deletar cliente v1 (Teste).");
                Console.Write("Qual opção? ");


                switch (Console.ReadLine())
                {
                    case "1":
                        listaDeClientes();
                        break;
                    case "2":
                        selectCliente();
                        break;
                    case "3":
                        gravar();
                        break;
                    case "4":
                        editar();
                        break;
                    case "5":
                        deletar();
                        break;
                }

                Console.Write("Fechar aperte 'n': ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing

                Console.ReadKey();
            }

        }

        public static void listaDeClientes()
        {
            var request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44312/api/v1/webservece/clientes");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta lista de clientes: " + responseString);

        }

        public static void selectCliente()
        {
            int num;
            Console.WriteLine("Digite 'id' de um Cliente!");
            num = Convert.ToInt32(Console.ReadLine());

            var request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44312/api/v1/webservece/"+num+"/cliente");
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta selecionar cliente: " + responseString);
        }

        public static void gravar()
        {
            
            String nome;
            Console.WriteLine("Digite o nome Cliente!");
            nome = Console.ReadLine();

            var request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44312/api/v1/webservece/cliente/gravar");
            var dadosDoUsuario = "{'Name':'" + nome + "'}";
            var data = Encoding.ASCII.GetBytes(dadosDoUsuario);

            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlendcoded";
            request.ContentType = "application/json";
            request.ContentLength = dadosDoUsuario.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta gravar cliente: " + responseString);

        }

        public static void editar()
        {

            int id;
            Console.WriteLine("Digite o 'id' do Cliente!");
            id = Convert.ToInt32(Console.ReadLine());

            String nome;
            Console.WriteLine("Digite o nome Cliente!");
            nome = Console.ReadLine();

            var request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44312/api/v1/webservece/cliente/"+id+"/editar");
            var dadosDoUsuario = "{'Name':'" + nome+"'}";
            var data = Encoding.ASCII.GetBytes(dadosDoUsuario);

            request.Method = "PUT";
            //request.ContentType = "application/x-www-form-urlendcoded";
            request.ContentType = "application/json";
            request.ContentLength = dadosDoUsuario.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta editar cliente: " + responseString);
        }

        public static void deletar()
        {
            int id;
            Console.WriteLine("Digite o 'id' do Cliente!");
            id = Convert.ToInt32(Console.ReadLine());

            var request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44312/api/v1/webservece/cliente/" + id + "/deletar");

            request.Method = "DELETE";
            //request.ContentType = "application/x-www-form-urlendcoded";
            request.ContentType = "application/json";
            
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("Resposta deletar cliente: " + responseString);
        }
    }
}
