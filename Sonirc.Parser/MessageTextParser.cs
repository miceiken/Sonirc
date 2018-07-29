using Sonirc.Models;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonirc.Parser
{
    public static class MessageTextParser
    {
        private static TextParser<string> CommandParser { get; } =
            from cmd in
                Character.Letter.AtLeastOnce().Or(Character.Digit.Repeat(3))
            select
                cmd.CreateString();

        // TODO: This can also be servername
        private static TextParser<User> PrefixParser { get; } =
            from prefix in
                Character.EqualTo(':').IgnoreThen(UserTextParser.UserParser)
            from _ in
                Character.EqualTo(' ')
            select
                prefix;

        private static TextParser<Message> MessageParser { get; } =
            from tags in
                TagsTextParser.TagsParser.Between(Character.EqualTo('@'), Character.EqualTo(' ')).OptionalOrDefault()
            from prefix in
                UserTextParser.UserParser.Between(Character.EqualTo(':'), Character.EqualTo(' ')).OptionalOrDefault()
            from command in
                CommandParser
            from parameters in
                ParametersTextParser.ParametersParser.OptionalOrDefault()
            from crlf in
                Character.EqualTo('\r').IgnoreThen(Character.EqualTo('\n')).OptionalOrDefault().AtEnd()
            select
                new Message
                {
                    Tags = tags,
                    Prefix = prefix,
                    Command = command,
                    Parameters = parameters
                };

        public static Message Parse(string input) =>
            MessageParser.Parse(input);
    }
}
