using Sonirc.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sonirc.Parsers.Tests
{
    public class UserParserText
    {
        [Fact]
        public void TestUserParsing()
        {
            Assert.Equal(
                new User { Nickname = "dan", Username = "d", Host = "localhost" }
            , UserTextParser.Parse("dan!d@localhost"));

            Assert.Equal(
                new User { Nickname = "dan", Username = "", Host = "localhost" }
            , UserTextParser.Parse("dan@localhost"));
        }
    }
}
