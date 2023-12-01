using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Teambuilderv2
{
     class Account_V1 :  RiotApi
    {
        public Account GetAccountByFullName(string Name, string Tagline) {

            string path = "https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/" + Name + "/" + Tagline; 
            var response = GET(GetURL2(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Account>(content);
            }
            else
            {
               
                return null;
            }
        }
    }
}
