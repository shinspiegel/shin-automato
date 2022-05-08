using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;

namespace DiscordBot.utils
{
    static class Events
    {
        public static async Task GetReaction(CommandContext ctx, DiscordMessage msg)
        {
            var reaction = await Program.bot.interactivity.WaitForReactionAsync((MessageReactionAddEventArgs r) => r.Message.Id == msg.Id && !r.User.IsBot && r.User.Id == ctx.Member.Id);
            var user = reaction.Result.User as DiscordMember;
            
            var rolesDic = Messages.Cargos(); //lista

            ulong Id;
            bool hasRole = rolesDic.TryGetValue(reaction.Result.Emoji.GetDiscordName(), out Id);
            if (hasRole == true)
            {
                var role = ctx.Guild.GetRole(Id);
                await user.GrantRoleAsync(role);
            } 
        }
    }
}