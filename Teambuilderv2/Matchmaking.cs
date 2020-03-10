using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Teambuilderv2
{
    class Matchmaking
    {
        Databaseconnection dbc = new Databaseconnection();

        class Player
        {
            public String name;
            public double rating;
            
            public Player(String name, double rating)
            {
                this.name = name;
                this.rating = rating;
            }
        }

        private double promotionBias(String tier)
        {
            return 0;
        }

        private int romanToDecimal(String numeral)
        {
            switch (numeral)
            {
                case "I":
                    return 1;
                case "II":
                    return 2;
                case "III":
                    return 3;
                case "IV":
                    return 4;
                default:
                    return 0;
            }
        }

        private String[] tiers = { "IRON", "BRONZE", "SILVER", "GOLD", "PLATINUM", "DIAMOND", "MASTER", "GRANDMASTER", "CHALLENGER" };

        public double rank(String playerName)
        {
            try
            {
                dbc.connection();
                SqlCommand wr = new SqlCommand("SELECT TotalWins,TotalLooses FROM Players WHERE PlayerName=@summonername", dbc.cnn);
                wr.Parameters.Add("@summonername",playerName);
                //  double winrate = (double)wr.ExecuteScalar();
                Console.WriteLine("");
                Summoner_V4 summoner = new Summoner_V4();
                string id = summoner.GetSummonerByName(playerName).Id;

                League_V4 league = new League_V4();
                string tier = league.GetLeagueByName(id).FirstOrDefault().tier;
                string rank = league.GetLeagueByName(id).FirstOrDefault().rank;
                int lp = league.GetLeagueByName(id).FirstOrDefault().leaguePoints;
               int leaguepoints = lp + 400 * Array.IndexOf(tiers, tier)+(romanToDecimal(rank)-1)*100;
                Console.WriteLine(leaguepoints);
                dbc.close();
                 return leaguepoints;
                 
                // return (Array.IndexOf(tiers, tier) - 3) * 0.25 + 3 + (4 - romanToDecimal(rank)) * 0.125 + promotionBias(tier);
               
            }
            catch
            {
                Console.WriteLine("FEHLER BRUDI");
            }
            return 3.0;
        }

        private double getAverageRating(List<Player> players)
        {
            double average = 0;

            foreach (Player player in players)
            {
                average += player.rating;
            }

            return average / players.Count;
        }

        private Player findClosest(List<Player> players, double targetRating)
        {
            double minDelta = double.PositiveInfinity;
            Player minPlayer = players.First();

            foreach (Player player in players)
            {
                if (Math.Abs(targetRating - player.rating) < minDelta)
                {
                    minPlayer = player;
                    minDelta = Math.Abs(targetRating - player.rating);
                }
            }

            return minPlayer;
        }

        public String[] matchmake(String[] names)
        {

            List<Player> players = new List<Player>();

            for (int i = 0; i < 10; i++)
            {
                players.Add(new Player(names[i], rank(names[i])));
            }

            List<Player> team1 = new List<Player>();
            List<Player> team2 = new List<Player>();

            double team1Average = 0;
            double team2Average = 0;

            double totalAverage = getAverageRating(players);

            int firstIndex = new Random().Next(10);
            Player first = players[firstIndex];
            players.RemoveAt(firstIndex);
            team1.Add(first);
            team1Average = first.rating;

            int secondIndex = new Random().Next(9);
            Player second = players[secondIndex];
            players.RemoveAt(secondIndex);
            team2.Add(second);
            team2Average = second.rating;
            
            for (int i = 2; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    double skillDelta = team1Average - totalAverage;
                    Player closest = findClosest(players, totalAverage - skillDelta);
                    team1.Add(closest);
                    players.RemoveAt(players.IndexOf(closest));
                    team1Average = getAverageRating(team1);
                } else
                {
                    double skillDelta = team2Average - totalAverage;
                    Player closest = findClosest(players, totalAverage - skillDelta);
                    team2.Add(closest);
                    players.RemoveAt(players.IndexOf(closest));
                    team2Average = getAverageRating(team2);
                }

            }

            team1.AddRange(team2);

            String[] playerNames = new string[10];

            for (int i = 0; i < 10; i++)
            {
                playerNames[i] = team1[i].name;
            }

            return playerNames;
        }
    }
}
