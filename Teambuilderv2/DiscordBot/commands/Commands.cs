using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
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
          await ctx.Channel.SendMessageAsync($"{Playername[0]} {Playername[1]}");
            ForwardMessageToProgramm(Playername[0], Playername[1]);
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
