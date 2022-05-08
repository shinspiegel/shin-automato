using System;
using DSharpPlus;

namespace DiscordBot
{
    static class Program
    {
        public static Bot bot;
        public static ulong[] adm;

        static void Main(string[] args)
        {
            adm = new ulong[] {
                0, // Lista de moderação, caso num futuro tenha mais comandos nisso e precise
            };

            bot = new Bot();
            bot.Run("TOKEN").GetAwaiter().GetResult();
        }
    }
}
