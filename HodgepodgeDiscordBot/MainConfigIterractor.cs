using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HodgepodgeDiscordBot
{
    public class MainConfigIterractor
    {
        private static MainConfig _config;
        public MainConfig Config
        {
            get
            {
                if (_config == null) 
                    _config = ReadConfig();

                return _config;
            }
        }

        private MainConfig ReadConfig()
        {
            //string json = File.ReadAllText("Configs/mainConfig.json");
            //return JsonConvert.DeserializeObject<MainConfig>(json);

            return new MainConfig()
            {
                Token = Environment.GetEnvironmentVariable("token"),
                CmdPrefix = Environment.GetEnvironmentVariable("cmdPrefix")
            };
        }
    }
}
