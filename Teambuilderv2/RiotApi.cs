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
          //  Key = "";
        }
        protected string GetKey()
        {
            return System.IO.File.ReadAllText(@"C:\Users\dome2\Documents\RiotApiKey.txt");
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
            Key = GetKey();
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }
        public string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }

    }
}
