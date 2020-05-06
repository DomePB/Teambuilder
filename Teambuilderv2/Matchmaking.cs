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
      //  Dictionary<String, Rank> playerCache;

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

        private Rank getRank(String playerName)
        {
            try
            {
                Summoner_V4 summoner = new Summoner_V4();
                string id = summoner.GetSummonerByName(playerName).Id;
               
             
                League_V4 league = new League_V4();
                if (league.GetLeagueByName(id).FirstOrDefault().queueType.Equals("RANKED_SOLO_5x5"))
                {
                    
                    
                    string tier = league.GetLeagueByName(id).FirstOrDefault().tier;
                    Console.WriteLine(tier);
                    string rank = league.GetLeagueByName(id).FirstOrDefault().rank;
                    int lp = league.GetLeagueByName(id).FirstOrDefault().leaguePoints;
                    return new Rank(lp, rank, tier);
                }
                else
                {
                 
                     string tier = league.GetLeagueByName(id).LastOrDefault().tier;
                     string rank = league.GetLeagueByName(id).LastOrDefault().rank;
                     int lp = league.GetLeagueByName(id).LastOrDefault().leaguePoints;
                    return new Rank(lp, rank, tier);

                }
      
            }
            catch
            {
                return new Rank(0, "GOLD", "IV");
            }
               
            
           
            
        }
        private double getwinrate(String playerName)
        {
            try
            {
                dbc.connection();
                SqlCommand wins = new SqlCommand("SELECT TotalWins FROM Players WHERE PlayerName=@summonername", dbc.cnn);
                wins.Parameters.Add("@summonername", playerName);
                Int32 Anzahlwins = (Int32)wins.ExecuteScalar();
                SqlCommand looses = new SqlCommand("SELECT TotalLooses FROM Players WHERE PlayerName=@summonername", dbc.cnn);
                looses.Parameters.Add("@summonername", playerName);
                Int32 Anzahllooses = (Int32)looses.ExecuteScalar();
                double winrate =  (double)Anzahlwins/ ((double)Anzahlwins + (double)Anzahllooses);
                dbc.close();
               
                return Math.Asin(2 * winrate - 1) * 1 / (1 + Math.Exp(3 - (Anzahlwins + Anzahllooses)));
            }
            catch {
                return 0.0;
            }
           
        }

        public double rank(String playerName)
        {
          
                Rank playerRank;
         

            if (Program.playerCache.ContainsKey(playerName)) 
                {
                    playerRank = Program.playerCache[playerName];
                  
                }
                else
                {
                    playerRank = getRank(playerName);
                    Program.playerCache.Add(playerName, playerRank);
                }

                dbc.close();

            double ranking = playerRank.lp + 400 * Array.IndexOf(tiers, playerRank.tier) + (4-romanToDecimal(playerRank.rank)) * 100 + 1000 * getwinrate(playerName);
            Console.WriteLine(playerName+" "+ ranking);

                return playerRank.lp + 400 * Array.IndexOf(tiers, playerRank.tier) + (4-romanToDecimal(playerRank.rank)) * 100 + 1000 * getwinrate(playerName);

            
          
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

            Player best = new Player("ERROR", 0.0);
            Player secondBest = new Player("ERROR",0.0);

            foreach (Player player in players)
            {
                
                if (player.rating > best.rating)
                {
                    best = player;
                }
                else if (player.rating > secondBest.rating)
                {
                    secondBest = player;
                }
            }

            int firstIndex;
            if (best.rating - secondBest.rating > 500)
            {

                firstIndex = players.IndexOf(best);
                Console.WriteLine("ayayayayayay");
            }
            else
            {
                firstIndex = new Random().Next(10);
            }


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
            Random rng = new Random();

            team1 = team1.OrderBy(a => rng.Next()).ToList(); 

            team2 = team2.OrderBy(a => rng.Next()).ToList();

            team1.AddRange(team2);

            String[] playerNames = new string[10];

            for (int i = 0; i < 10; i++)
            {
                playerNames[i] = team1[i].name;
            }

            Console.WriteLine("team1av: "+team1Average);
            Console.WriteLine("team2av: "+team2Average);
            return playerNames;
        }
    }
}
