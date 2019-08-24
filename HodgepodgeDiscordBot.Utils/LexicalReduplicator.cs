using System;
using System.Collections.Generic;
using System.Text;

namespace HodgepodgeDiscordBot.Utils
{
    public class LexicalReduplicator
    {
        static readonly char[] vowelsRu = { 'а', 'е', 'ё', 'и', 'о', 'у', 'э', 'ю', 'я' };

        public static string Huplicate(string input)
        {
            var ind = input.IndexOfAny(vowelsRu);
            var data = input.Substring(ind + 1);

            var repeat = "";
            switch (input[ind])
            {
                case 'а':
                    repeat = "я";
                    break;
                case 'о':
                    repeat = "ё";
                    break;
                case 'у':
                    repeat = "ю";
                    break;
                case 'э':
                    repeat = "е";
                    break;
                default:
                    break;
            }

            return "ху" + repeat + data;
        }
    }
}
