using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Logic
{
    public class DogLogic
    {
        public string GetApi()
        {
            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create("https://dog.ceo/api/breeds/image/random/3");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
        }
    }
}
