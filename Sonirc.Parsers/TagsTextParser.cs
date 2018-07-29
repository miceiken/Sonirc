using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Superpower;
using Superpower.Parsers;
using Sonirc.Models;

namespace Sonirc.Parsers
{
    public static class TagsTextParser
    {
        private static TextParser<char> ExceptIllegalParser { get; } =
            Character.ExceptIn('\0', '\r', '\n', ';', ' ');

        private static TextParser<Tag> TagParser { get; } =
            from key in
                Character.LetterOrDigit.Or(Character.In('.', '-')).AtLeastOnce()
            from value in
                Character.EqualTo('=').IgnoreThen(ExceptIllegalParser.Many().OptionalOrDefault()).OptionalOrDefault()
            select
                new Tag
                {
                    Key = key.CreateString(),
                    Value = value.CreateString()
                };

        internal static TextParser<Tag[]> TagsParser { get; } =
            TagParser.AtLeastOnceDelimitedBy(Character.EqualTo(';')).AtEnd();

        public static IEnumerable<Tag> Parse(string input) =>
            TagsParser.Parse(input);
    }
}
