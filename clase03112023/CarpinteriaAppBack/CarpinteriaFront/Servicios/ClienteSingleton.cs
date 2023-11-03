using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaFront.Servicios
{
    public class ClienteSingleton
    {
        private static ClienteSingleton instancia;

        private HttpClient client;

        private ClienteSingleton()
        {
            client = new HttpClient();
        }

        public static ClienteSingleton getInstance()
        {

            if (instancia == null)
            {
                instancia = new ClienteSingleton();
            }
            return instancia;

        }

        //ACA LLAMO LOS METODOS DE LA API

        public async Task<string> GetAsync(string urlGet) 
        {

            var result = await client.GetAsync(urlGet);

            var content = "";

            if (result.IsSuccessStatusCode) //result.StatusCode == HttpStatusCode.OK || System.Net.HttpStatusCode.OK - Solo que importo arriba el system.Net
            {
                content = await result.Content.ReadAsStringAsync();
            }
            //ME DEVUELVE UN JSON
            return content;
               
        }

        public async Task<string> PostAsync(string urlPost,string dataJson)
        {
            StringContent content = new StringContent(dataJson,Encoding.UTF8,"application/json");

            var result = await client.PostAsync(urlPost, content);

            var response = "";

            if (result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }

            return response;
        }

    }
}
