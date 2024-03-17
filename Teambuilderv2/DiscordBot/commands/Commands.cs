using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teambuilderv2.DiscordBot.commands
{
    public class Commands : BaseCommandModule
    {
        
        [Command("test")]
        public async Task testcmd(CommandContext ctx) {
            await ctx.Channel.SendMessageAsync("test");
        }

        [Command("play")]
        public async Task playcmd(CommandContext ctx, params string[] text) {
            string result = string.Join(" ", text);
            string[] Playername = result.Split('#');
          await ctx.Channel.SendMessageAsync($"Logged in player: {Playername[0]} {Playername[1]}");
            ForwardMessageToProgramm(Playername[0], Playername[1]);
        }

        [Command("stats")]

        public async Task statscmd(CommandContext ctx, params string[] playernamearr) {
            string playername = string.Join(" ", playernamearr);
            Databaseconnection con = new Databaseconnection();

            con.connection();
            SqlDataAdapter testad = new SqlDataAdapter("SELECT TotalWins, TotalLooses FROM Players WHERE PlayerName = @player ", con.cnn);
            testad.SelectCommand.Parameters.AddWithValue("@player", playername);
            DataTable Playerstats = new DataTable();
            testad.Fill(Playerstats);
            con.close();

            int wins=0;
            int losses=0;

            if (Playerstats.Rows.Count > 0) {
                Console.WriteLine("tester 1" + Playerstats.Rows[0]);
                wins = Convert.ToInt32(Playerstats.Rows[0]["TotalWins"]);
                losses = Convert.ToInt32(Playerstats.Rows[0]["TotalLooses"]);
            }

            await ctx.Channel.SendMessageAsync($"{playername} Wins: {wins}   Defeats: {losses}");
        }


        private static void ForwardMessageToProgramm(string Playername, string tagLine) {
            try {
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "Pipe1", PipeDirection.Out);
                    pipeClient.Connect();
                using (StreamWriter sw = new StreamWriter(pipeClient))
                    {
                        sw.WriteLine(Playername);
                        sw.WriteLine(tagLine);
                    }
                pipeClient.Close();
                
            } catch { 
                throw new Exception();
            }
        }
    }
}
