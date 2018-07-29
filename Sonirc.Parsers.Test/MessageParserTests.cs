using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonirc.Models;
using Sonirc.Parsers;
using Xunit;

namespace Sonirc.Parsers.Tests
{
    public class MessageParserTests
    {
        [Fact]
        public void TestModelsEmpty()
        {
            Assert.Equal(new Message(), new Message());
        }

        [Fact]
        public void TestModelsEqual()
        {
            Assert.Equal(
                new Message
                {
                    Tags = null,
                    Source = null,
                    Verb = "CAP",
                    Parameters = new string[] { "REQ", "sasl" }
                },
                new Message
                {
                    Tags = null,
                    Source = null,
                    Verb = "CAP",
                    Parameters = new string[] { "REQ", "sasl" }
                }
            );
        }

        [Fact]
        public void TestCapCommandMessage()
        {
            Assert.Equal(new Message
            {
                Tags = null,
                Source = null,
                Verb = "CAP",
                Parameters = new string[] { "REQ", "sasl" }
            }, MessageTextParser.Parse("CAP REQ :sasl"));
        }

        [Fact]
        public void TestCapCommandMessageWithServername()
        {
            Assert.Equal(new Message
            {
                Tags = null,
                Source = "irc.example.com",
                Verb = "CAP",
                Parameters = new string[] { "LS", "*", "multi-prefix extended-join sasl" }
            }, MessageTextParser.Parse(":irc.example.com CAP LS * :multi-prefix extended-join sasl"));
        }

        [Fact]
        public void TestPrivmsgMessage()
        {
            Assert.Equal(new Message
            {
                Tags = new Tag[] { new Tag { Key = "id", Value = "234AB" } },
                Source = "dan!d@localhost",
                Verb = "PRIVMSG",
                Parameters = new string[] { "#chan", "Hey what's up!" }
            }, MessageTextParser.Parse("@id=234AB :dan!d@localhost PRIVMSG #chan :Hey what's up!"));
        }
    }
}
