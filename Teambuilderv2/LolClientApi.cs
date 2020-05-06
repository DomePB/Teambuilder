using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace Teambuilderv2
{
    class LolClientApi
    {
        private string url = "https://127.0.0.1:55668/lol-lobby/v2/lobby/members"; 

        protected HttpResponseMessage GET()
        {
            Console.WriteLine("test");
            using(HttpClient client = new HttpClient())
            {
                Console.WriteLine("HALLOOOOOOOO");
                var result = client.GetAsync(url);
                Console.WriteLine("warte");
                result.Wait();
                Console.WriteLine("x "+result.Result);
                return result.Result;
            }

        }
        public Member[] GetMembers()
        {
            var response = GET();
            string content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Member[]>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
