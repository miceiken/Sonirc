using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Parsers
{
    public static class Extensions
    {
        public static string CreateString(this char[] chars)
        {
            if (chars == null)
                return null;
            return new string(chars);
        }

        public static string[] CreateStringArray(this char[] chars)
        {
            var str = CreateString(chars);
            if (str == null)
                return new string[] { };
            return new[] { str };
        }
    }
}
