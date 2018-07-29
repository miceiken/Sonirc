using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superpower;
using Superpower.Parsers;

namespace Sonirc.Parsers
{
    public static class HostNameTextParser
    {
        private static TextParser<char[]> ShortNameParser { get; } =
            from first in
                Character.LetterOrDigit
            from middle in
                Character.LetterOrDigit.Or(Character.EqualTo('-')).Many()
            from last in
                Character.LetterOrDigit.Many()
            select
                new char[] { first }.Concat(middle).Concat(last).ToArray();

        internal static TextParser<string> HostNameParser { get; } =
            from hostname in
                Span.MatchedBy(ShortNameParser.AtLeastOnceDelimitedBy(Character.EqualTo('.'))).AtEnd()
            select
                hostname.ToStringValue();

        public static string Parse(string input) =>
            HostNameParser.Parse(input);
    }
}
