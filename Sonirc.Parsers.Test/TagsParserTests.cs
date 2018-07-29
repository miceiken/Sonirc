using System.Linq;
using Superpower;
using System;
using Xunit;
using Sonirc.Models;

namespace Sonirc.Parsers.Tests
{
    public class TagsParserTests
    {
        [Fact]
        public void TestModelsEmpty()
        {
            Assert.Equal(
                new Tag(),
                new Tag()
            );

            Assert.Equal(
                new[] { new Tag() },
                new[] { new Tag() }
            );
        }

        [Fact]
        public void TestModelsEqual()
        {
            Assert.Equal(
                new[] { new Tag { Key = "id", Value = "123AB" } },
                new[] { new Tag { Key = "id", Value = "123AB" } }
            );
        }

        [Fact]
        public void TestModelsDifferentOrder()
        {
            Assert.NotEqual(
                new[] {
                    new Tag { Key = "id", Value = "123AB" },
                    new Tag { Key= "netsplit", Value="tur"}
                },
                new[] {
                    new Tag { Key= "netsplit", Value="tur"},
                    new Tag { Key = "id", Value = "123AB" }
                }
            );
        }

        [Fact]
        public void TestNoTags()
        {
            Assert.Throws<ParseException>(() => TagsTextParser.Parse(""));
        }

        [Fact]
        public void TestInvalidTags()
        {
            Assert.Throws<ParseException>(
                () => TagsTextParser.Parse(";")
            );

            Assert.Throws<ParseException>(
                () => TagsTextParser.Parse("=;")
            );

            Assert.Throws<ParseException>(
                () => TagsTextParser.Parse("=a;")
            );

            Assert.Throws<ParseException>(
                () => TagsTextParser.Parse("id=1;;")
            );
        }

        [Fact]
        public void TestKeyValue()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = "123AB" }
            }, TagsTextParser.Parse("id=123AB"));
        }

        [Fact]
        public void TestKeyNoValue()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = null }
            }, TagsTextParser.Parse("id"));
        }

        [Fact]
        public void TestEmptyKeyValue()
        {
            Assert.Throws<ParseException>(
                () => TagsTextParser.Parse("=123AB;")
            );
        }

        [Fact]
        public void TestKeyEmptyValue()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = "" }
            }, TagsTextParser.Parse("id="));
        }

        [Fact]
        public void TestMultipleKeyValues()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = "123AB" },
                new Tag { Key= "netsplit", Value="tur"}
            }, TagsTextParser.Parse("id=123AB;netsplit=tur"));
        }

        [Fact]
        public void TestMultipleKeyValuesOneNoValue()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = null },
                new Tag { Key= "netsplit", Value="tur"}
            }, TagsTextParser.Parse("id;netsplit=tur"));
        }

        [Fact]
        public void TestMultipleKeyValuesOneEmptyValue()
        {
            Assert.Equal(new[] {
                new Tag { Key = "id", Value = "" },
                new Tag { Key= "netsplit", Value="tur"}
            }, TagsTextParser.Parse("id=;netsplit=tur"));
        }

        [Fact]
        public void TestTagsFromPrivmsg()
        {
            Assert.Equal(
                new[] {
                    new Tag { Key = "id", Value = "234AB" },
                }, MessageTextParser.Parse("@id=234AB :dan!d@localhost PRIVMSG #chan :Hey what's up!").Tags
            );
        }
    }
}
