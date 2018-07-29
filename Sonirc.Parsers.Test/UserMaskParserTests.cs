using Sonirc.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sonirc.Parsers.Tests
{
    public class UserMaskParserTests
    {
        [Fact]
        public void TestValidUserMasks()
        {
            Assert.Equal(
                new Fullhost
                {
                    Nickname = "dan",
                    Username = "d",
                    Hostname = "localhost"
                }, FullhostTextParser.Parse("dan!d@localhost")
            );

            Assert.Equal(
                new Fullhost
                {
                    Nickname = "dan",
                    Username = null,
                    Hostname = "localhost"
                }, FullhostTextParser.Parse("dan@localhost")
            );
        }

        [Fact]
        public void TestUserMaskParsingFromPrivmsg()
        {
            Assert.Equal(
                new Fullhost
                {
                    Nickname = "dan",
                    Username = "d",
                    Hostname = "localhost"
                }, FullhostTextParser.Parse(MessageTextParser.Parse("@id=234AB :dan!d@localhost PRIVMSG #chan :Hey what's up!").Source)
            );
        }
    }
}
