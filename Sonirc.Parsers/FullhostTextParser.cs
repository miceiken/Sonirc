using Sonirc.Models;
using Superpower;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Parsers
{
    public static class FullhostTextParser
    {
        internal static TextParser<Fullhost> FullhostParser { get; } =
            from nickname in
                Character.LetterOrDigit.AtLeastOnce()
            from user in
                Character.EqualTo('!').IgnoreThen(Character.LetterOrDigit.AtLeastOnce()).OptionalOrDefault()
            from host in
                Character.EqualTo('@').IgnoreThen(Character.LetterOrDigit.AtLeastOnce()).OptionalOrDefault().AtEnd()
            select
                new Fullhost
                {
                    Nickname = nickname.CreateString(),
                    Username = user.CreateString(),
                    Hostname = host.CreateString()
                };

        public static Fullhost Parse(string input) =>
            FullhostParser.Parse(input);
    }
}
