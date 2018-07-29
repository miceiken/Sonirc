using Superpower;
using Superpower.Parsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sonirc.Parsers
{
    public static class ParametersTextParser
    {
        private static TextParser<char[]> ManySpaces { get; } =
            Character.EqualTo(' ').Many();

        private static TextParser<char> ExceptIllegalParser { get; } =
            Character.ExceptIn('\0', '\r', '\n', ':', ' ');

        private static TextParser<char[]> TrailingParser { get; } =
            Character.In(':', ' ').Or(ExceptIllegalParser).Many();

        private static TextParser<char[]> MiddleParser { get; } =
            from first in
                ExceptIllegalParser
            from rest in
                Character.EqualTo(':').Or(ExceptIllegalParser).Many()
            select
                new[] { first }.Concat(rest).ToArray();

        internal static TextParser<IEnumerable<string>> ParametersParser { get; } =
            from middle in
                ManySpaces.IgnoreThen(MiddleParser).Try().Many()
            from trailing in
                ManySpaces.IgnoreThen(Character.EqualTo(':')).IgnoreThen(TrailingParser).OptionalOrDefault()
            select
                middle.Select(Extensions.CreateString).Concat(trailing.CreateStringArray());

        public static IEnumerable<string> Parse(string input) =>
            ParametersParser.Parse(input);
    }
}
