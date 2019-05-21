using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HeroMonsterGame
{
    public static class StringHelpers
    {
        public static string ConvertToCamelCase(this string someString)
        {
            var stringToReturn = Regex.Replace(someString, "(\\B[A-Z])", " $1");
            return stringToReturn;
        }
    }
}
