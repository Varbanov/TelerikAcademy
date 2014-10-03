using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Client
{
    public class TicTacToeMain
    {
        static void Main()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:1268/")
            };


            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = 
                client.GetAsync("api/Game/create").Result;

            if (response.IsSuccessStatusCode)
            {
            }
            else
            { 
            }
            //no time for clients so far
        }
    }
}
