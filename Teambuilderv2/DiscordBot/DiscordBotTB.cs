using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Teambuilderv2.DiscordBot.commands;

namespace Teambuilderv2
{
    internal class DiscordBotTB
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        public async void start() 
        {
            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = "MTIxODY2MTIyMjk2Mjk1NDI2MQ.GWLX7E.VCrSk2UUe1LyNwiu6fmhV0bb_t5_3GFbdbbJIA",
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };
            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                EnableMentionPrefix = true,
                EnableDms = true
            };

            Commands = Client.UseCommandsNext(commandConfig);

            Commands.RegisterCommands<Commands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
