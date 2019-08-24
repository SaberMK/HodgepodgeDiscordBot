using Discord.Commands;
using HodgepodgeDiscordBot.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HodgepodgeDiscordBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        private readonly static char[] splitSymbols = { ' ', '\t' };

        [Command("echo")]
        public async Task Echo()
        {
            await Context.Channel.SendMessageAsync("♂FUCK♂YOU♂");
        }

        [Command("lexicalreduplicate")]
        public async Task LexicalReduplicate([Remainder]string message)
        {
            string msg = "";

            var data = message.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
            foreach (var m in data)
            {
                msg += $"{LexicalReduplicator.Huplicate(m)} ";
            }

            await Context.Channel.SendMessageAsync(msg);
        }
    }
}
