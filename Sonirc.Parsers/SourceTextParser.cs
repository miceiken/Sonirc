using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superpower;
using Superpower.Parsers;

namespace Sonirc.Parsers
{
    public static class SourceTextParser
    {
        internal static TextParser<string> SourceParser { get; } =
            from source in
                Span.MatchedBy(HostNameTextParser.HostNameParser).Or(Span.MatchedBy(FullhostTextParser.FullhostParser))
            select
                source.ToString();

        public static string Parse(string input) =>
            SourceParser.Parse(input);
    }
}
