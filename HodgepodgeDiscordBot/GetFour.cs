using System;
using System.Collections.Generic;
using System.Text;

namespace HodgepodgeDiscordBot
{
    public class GetFour : IGetFour
    {
        int IGetFour.GetFour()
        {
            return 4;
        }
    }
}
