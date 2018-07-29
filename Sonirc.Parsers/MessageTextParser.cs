using Sonirc.Models;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sonirc.Parsers
{
    public static class MessageTextParser
    {
        private static TextParser<string> VerbParser { get; } =
            from verb in
                Character.Letter.AtLeastOnce().Or(Character.Digit.Repeat(3))
            select
                verb.CreateString();

        private static TextParser<Message> MessageParser { get; } =
            from tags in
                TagsTextParser.TagsParser.Between(Character.EqualTo('@'), Character.EqualTo(' ')).OptionalOrDefault()
            from source in
                SourceTextParser.SourceParser.Between(Character.EqualTo(':'), Character.EqualTo(' ')).OptionalOrDefault()
            from verb in
                VerbParser
            from parameters in
                ParametersTextParser.ParametersParser.OptionalOrDefault()
            from crlf in
                Span.EqualTo("\r\n").OptionalOrDefault().AtEnd()
            select
                new Message
                {
                    Tags = tags,
                    Source = source,
                    Verb = verb,
                    Parameters = parameters
                };

        public static Message Parse(string input) =>
            MessageParser.Parse(input);
    }
}
