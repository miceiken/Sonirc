using System;
using System.Collections.Generic;
using System.Text;
using Sonirc.Parsers;
using Superpower;
using Xunit;
using Sonirc.Models;

namespace Sonirc.Parsers.Tests
{
    public class ParametersParserTests
    {
        [Fact]
        public void TestNoParameters()
        {
            // Assert.Throws<ParseException>(() => ParametersTextParser.Parse(""));
        }

        [Fact]
        public void TestInvalidParameters()
        {
        }

        [Fact]
        public void TestNoTrail()
        {
            Assert.Equal(new[] {
                "*", "LIST"
            }, ParametersTextParser.Parse("* LIST"));

            Assert.Equal(new[] {
                "#chan", "Hey!"
            }, ParametersTextParser.Parse("#chan Hey!"));

            Assert.Equal(new[] {
                "#chan", "Hey", "there!"
            }, ParametersTextParser.Parse("#chan Hey there!"));
        }

        [Fact]
        public void TestEmptyTrail()
        {
            Assert.Equal(new[] {
                "*", "LIST", ""
            }, ParametersTextParser.Parse("* LIST :"));
        }

        [Fact]
        public void TestTrail()
        {
            Assert.Equal(new[] {
                "*", "LS", "multi-prefix sasl"
            }, ParametersTextParser.Parse("* LS :multi-prefix sasl"));

            Assert.Equal(new[] {
                "REQ", "sasl message-tags foo"
            }, ParametersTextParser.Parse("REQ :sasl message-tags foo"));

            Assert.Equal(new[] {
                "#chan", "Hey!"
            }, ParametersTextParser.Parse("#chan :Hey!"));

            Assert.Equal(new[] {
                "#chan", "Hey there!"
            }, ParametersTextParser.Parse("#chan :Hey there!"));
        }
    }
}
