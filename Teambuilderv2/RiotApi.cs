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
            Key = "RGAPI-80ead96a-fa5f-4f4d-a99d-85da65c21fd9";
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
