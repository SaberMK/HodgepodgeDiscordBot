using Discord;
using Discord.Commands;
using Discord.WebSocket;
using HodgepodgeDiscordBot.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HodgepodgeDiscordBot
{
    class Program
    {
        DiscordSocketClient _client;
        public Program()
        {
            
        }

        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private async Task StartAsync()
        {
            Task.Run(Wakeuper.WakeUp);
            Console.WriteLine("After Wakeuper.WakeUp()");
            using (var services = ConfigureServices())
            {
                // get the client and assign to client 
                // you get the services via GetRequiredService<T>
                var client = services.GetRequiredService<DiscordSocketClient>();
                _client = client;

                // setup logging and the ready event
                client.Log += LogAsync;
                client.Ready += ReadyAsync;

                Console.WriteLine("Before bot started");
                // this is where we get the Token value from the configuration file, and start the bot
                await client.LoginAsync(TokenType.Bot, new MainConfigIterractor().Config.Token);
                await client.StartAsync();

                // we get the CommandHandler class here and call the InitializeAsync method to start things up for the CommandHandler service
                await services.GetRequiredService<CommandHandler>().InitializeAsync();

                await Task.Delay(-1);
            }
        }
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"Connected as -> [] :)");
            return Task.CompletedTask;
        }

        // this method handles the ServiceCollection creation/configuration, and builds out the service provider we can call on later
        private ServiceProvider ConfigureServices()
        {
            // this returns a ServiceProvider that is used later to call for those services
            // we can add types we have access to here, hence adding the new using statement:
            // using csharpi.Services;
            // the config we build is also added, which comes in handy for setting the command prefix!
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandHandler>()
                .AddSingleton<MainConfigIterractor>()
                .AddSingleton<CommandService>()
                .BuildServiceProvider();
        }
    }
}
