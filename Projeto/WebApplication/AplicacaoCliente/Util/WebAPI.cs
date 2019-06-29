using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCliente.Util
{
    public class WebAPI
    {
        public static string TOKEN = "123123123SDFS11"; ///api/cliente/listagem

        public static string URI = "https://localhost:44343/api/cliente";

        public static string RequestGET(string metodo, string parametro)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(URI + "/" + metodo);

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestPOST(string metodo, string jsonData)
        {
        
            var request = (HttpWebRequest)HttpWebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Token", TOKEN);
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
