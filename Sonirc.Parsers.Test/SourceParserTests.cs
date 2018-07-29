using System;
using System.Collections.Generic;
using System.Text;
using Superpower;
using Xunit;

namespace Sonirc.Parsers.Tests
{
    public class SourceParserTests
    {
        [Fact]
        public void TestInvalidHostNames()
        {
            var invalid = new string[]
            {
                "noInvalidCharacters!",
                "-mustStartWithLetterOrDigit",
                "noTwoDots.."
            };

            foreach (var host in invalid)
            {
                Assert.Throws<ParseException>(
                    () => SourceTextParser.Parse(host)
                );
            }
        }

        [Fact]
        public void TestValidHostNames()
        {
            var valid = new string[]
            {
                "domain",
                "domain.tld",
                "sub.domain.tld",
                "p90.also.valid",
                "also.with-dash.tld"
            };

            foreach (var host in valid)
            {
                Assert.Equal(host, SourceTextParser.Parse(host));
                Assert.Equal(host, HostNameTextParser.Parse(host));
            }
        }

        [Fact]
        public void TestInvalidUserMasks()
        {
            var invalid = new string[]
            {
            };

            foreach (var host in invalid)
            {
                Assert.Throws<ParseException>(
                    () => FullhostTextParser.Parse(host)
                );
            }
        }

        [Fact]
        public void TestValidUserMasks()
        {
            var valid = new string[]
            {
            };

            foreach (var host in valid)
            {
                Assert.Equal(host, SourceTextParser.Parse(host));
                Assert.Equal(host, HostNameTextParser.Parse(host));
            }
        }
    }
}
