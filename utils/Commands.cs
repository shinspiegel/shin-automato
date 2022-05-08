
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System.Linq;

namespace DiscordBot.utils
{
    public class Commands : BaseCommandModule
    {
        [Command("init")]
        public async Task Init(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            DiscordMessage uni = await ctx.Channel.SendMessageAsync(Messages.Uni());
            DiscordMessage fe = await ctx.Channel.SendMessageAsync(Messages.Ferramentas());
            DiscordMessage pro = await ctx.Channel.SendMessageAsync(Messages.Proficiencias());


            // NOTA MENTAL: arrumar esse codigo repetido.
            await uni.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Unicesumar:"));

            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":C:"));
            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":C#:"));
            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Python:"));
            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Ruby:"));
            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Javascript:"));
            await fe.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Java:"));

            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Pro:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Matematica:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Analise:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Front-end:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Back-end:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":Embarcado:"));
            await pro.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":DaraScience:"));


            while (true)
            {
                await Events.GetReaction(ctx, uni);
                await Events.GetReaction(ctx, fe);
                await Events.GetReaction(ctx, pro);
            }
        }
    }
}
