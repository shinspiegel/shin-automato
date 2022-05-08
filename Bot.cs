using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace DiscordBot
{
    class Bot
    {
        public DiscordClient client { get; set; }
        public CommandsNextExtension commands { get; set; }
        public InteractivityExtension interactivity { get; set; }
        public InteractivityExtension reaction { get; set; }

        public async Task Run(string token)
        {
            var config = new DiscordConfiguration
            {
                Token = token,
                Intents = DiscordIntents.GuildMessageReactions
                        | DiscordIntents.GuildEmojis
                        | DiscordIntents.GuildMembers
                        | DiscordIntents.Guilds
                        | DiscordIntents.GuildMessages,
            };

            client = new DiscordClient(config);

            var commfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "shin!" } // GRANDE SHIN!!!
            };

            commands = client.UseCommandsNext(commfig);

            interactivity = client.UseInteractivity(new InteractivityConfiguration { Timeout = Timeout.InfiniteTimeSpan });

            await client.ConnectAsync();

            commands.RegisterCommands<utils.Commands>();

            await Task.Delay(-1);
        }
    }
}