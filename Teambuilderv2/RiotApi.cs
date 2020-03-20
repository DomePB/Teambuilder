using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Teambuilderv2
{
    class RiotApi
    {
        private string Key { get; set; }
        private string Region { get; set; }

        public RiotApi()
        {
            Region = "euw1";
            Key = "RGAPI-73a1296c-2f67-425e-99ea-e77d76f37b01";
        }
        protected HttpResponseMessage GET(string URL) 
        { 
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();
                return result.Result;
            }
        }

        protected string GetURL(string path)
        { 
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }
        public string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }

    }
}
