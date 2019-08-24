using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HodgepodgeDiscordBot.Utils
{
    public static class Wakeuper
    {
        private static readonly int WAKEUP_DELAY = 29 * 60 * 1000;
        
        public static async Task WakeUp()
        {
            HttpClient client = new HttpClient();
            string wakeupUrl = Environment.GetEnvironmentVariable("wakeupUrl");
            while (true)
            {
                await client.GetAsync(wakeupUrl);
                Thread.Sleep(WAKEUP_DELAY);
            }
        }
    }
}
