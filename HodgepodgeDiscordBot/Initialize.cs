using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HodgepodgeDiscordBot
{
    public class Initialize
    {
        private readonly CommandService _commands;
        private readonly DiscordSocketClient _client;

        public Initialize(CommandService commands = null, DiscordSocketClient client = null)
        {
            _commands = commands ?? new CommandService();


            _client = client ?? new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
        }

        public async Task Work()
        {
            await _client.LoginAsync(TokenType.Bot, new MainConfigIterractor().Config.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public IServiceProvider BuildServiceProvider() => new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton<IGetFour, GetFour>()
            .AddSingleton<CommandHandler>()
            .BuildServiceProvider();

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
