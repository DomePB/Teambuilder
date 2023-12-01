using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teambuilderv2
{
    class Summoner_V4 : RiotApi
    {
      public Summoner GetSummonerByName(string SummonerName)
        {
            string path = "lol/summoner/v4/summoners/by-name/" + SummonerName;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Summoner>(content);
            }
            else
            {
                return null;
            }
        }
        public Summoner GetSummonerByPuuid(string puuid) 
        {
            string path = "lol/summoner/v4/summoners/by-puuid/" + puuid;
            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Summoner>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
