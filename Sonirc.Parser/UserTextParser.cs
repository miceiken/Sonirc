using Sonirc.Models;
using Superpower;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Parser
{
    public static class UserTextParser
    {
        internal static TextParser<User> UserParser { get; } =
            from nickname in
                Character.LetterOrDigit.AtLeastOnce()
            from user in
                Character.EqualTo('!').IgnoreThen(Character.LetterOrDigit.AtLeastOnce()).OptionalOrDefault()
            from host in
                Character.EqualTo('@').IgnoreThen(Character.LetterOrDigit.AtLeastOnce()).OptionalOrDefault()
            select
                new User
                {
                    Nickname = new string(nickname),
                    Username = new string(user),
                    Host = new string(host)
                };

        public static User Parse(string input) =>
            UserParser.Parse(input);
    }
}
