using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //importar biblioteca Client
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Testando Console Basico
            Console.WriteLine("Testando C# - EducaCiencia FastCode");
            Console.ReadLine();
            */

            
            //PutAPI_Java
            PutAPI_Java();
            Console.ReadKey();
            
        }

        

        //Put API Java SpringBoot - WebRequest
        public static void PutAPI_Java()
        {
            string endpointPut = "http://localhost:8080/api/JPA/clientes/";
            string id = "1";
            WebRequest request = WebRequest.Create(endpointPut + id);
            request.Method = "PUT";
            request.ContentType = "application/json; charset=UTF-8";
            string json = 
                "{" +
                "\"id\":\"1\"," +
                "\"nome\":\"PUT-EducaCiencia\"," +
                "\"email\":\"PUT-Educaciencia@FastCode.com.br\"" +
                "}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("PUT ID " + id + " => ok " );
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("fail Post");
            }
        }


        
    }
}
