using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teambuilderv2
{
    class League_V4 : RiotApi
    {
        public List<League> GetLeagueByName(string SummonerId)
        {
            string path = "lol/league/v4/entries/by-summoner/" + SummonerId;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            string defaultjson = @"{'queueType': 'RANKED_SOLO_5x5','tier':'GOLD','rank': 'IV'}";

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if(JsonConvert.DeserializeObject<List<League>>(content).Count != 0)
                {
                    return JsonConvert.DeserializeObject<List<League>>(content);
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<League>>(defaultjson);
                }
                
            }
            else
            {
                //return JsonConvert.DeserializeObject<List<League>>(defaultjson);
                return null;
            }
        }
    }
}
