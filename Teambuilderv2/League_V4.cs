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
            string path = "league/v4/entries/by-summoner/" + SummonerId;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<League>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
