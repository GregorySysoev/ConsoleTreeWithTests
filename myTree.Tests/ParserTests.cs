using System;
using Xunit;

namespace myTree.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("@^2!*", "wrongArgs")]
        [InlineData("wrongArgs", "-123", "12312")]
        [InlineData("", "-123", "12312")]
        public void Parse_badArgs_WasError(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.WasError);
        }

        [Theory]
        [InlineData("-d", "5")]
        [InlineData("--depth", "5")]
        [InlineData("-d", "5", "-h")]
        [InlineData("-h", "-d", "5")]
        [InlineData("-h", "-d", "5", "-d", "5")]
        [InlineData("-d", "1", "--depth", "5")]
        public void Parse_Depth5_Depth5(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.Equal(5, options.Depth);
            Assert.False(options.WasError);
        }

        [Fact]
        public void Parse_withoutArgs_NotWasError()
        {
            Options options;
            string[] args = new string[] { };

            Parser.Parse(args, out options);

            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("--help")]
        [InlineData("-d", "1", "--help")]
        [InlineData("--help", "--help")]
        public void Parse_Help_NeedHelp(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.NeedHelp);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-s")]
        [InlineData("--size")]
        [InlineData("--size", "-d", "1")]
        [InlineData("-h", "--size", "-d", "1")]
        public void Parse_Size_NeedSize(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.NeedSize);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-h")]
        [InlineData("--human-readable")]
        [InlineData("-d", "2", "-h")]
        [InlineData("-d", "2", "-h", "-s", "-h")]
        public void Parse_HumanReadable_NeedHumanReadable(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.NeedHumanReadable);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-r")]
        [InlineData("--reverse")]
        [InlineData("-d", "2", "-r")]
        [InlineData("-d", "2", "-r", "-s", "-r")]
        public void Parse_orderReverse_Reverse(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.sorting.Reverse);
            Assert.False(options.WasError);
        }


        [Theory]
        [InlineData("-o")]
        [InlineData("--order-by")]
        [InlineData("-o", "-d")]
        [InlineData("-o", "1")]
        [InlineData("-o", "notExistingFlag")]
        public void Parse_orderWithoutFlag_or_orderWithNotExistFlag_WasError(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.WasError);
        }

        [Theory]
        [InlineData("-o", "a")]
        [InlineData("--order-by", "a")]
        [InlineData("-s", "-o", "a")]
        [InlineData("-o", "a", "-s")]
        [InlineData("-s", "-o", "a", "-d", "1")]
        [InlineData("-s", "-o", "a", "-d", "1", "-o", "s")]
        public void Parse_orderByAlphabet_OrderByAlphabet(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.sorting.OrderByAlphabet);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-o", "s")]
        [InlineData("-s", "-o", "s")]
        [InlineData("-o", "s", "-s")]
        [InlineData("-s", "-o", "s", "-d", "1")]
        [InlineData("-s", "--order-by", "s", "-d", "1", "-o", "s")]
        public void Parse_orderBySize_OrderBySize(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.sorting.OrderBySize);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-o", "t")]
        [InlineData("-s", "-o", "t")]
        [InlineData("-o", "t", "-s")]
        [InlineData("-s", "-o", "t", "-d", "1")]
        [InlineData("-s", "--order-by", "t", "-d", "1", "-o", "a")]
        public void Parse_OrderByDateOfTransorm_OrderByDateOfTransorm(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.sorting.OrderByDateOfTransorm);
            Assert.False(options.WasError);
        }

        [Theory]
        [InlineData("-o", "c")]
        [InlineData("-s", "-o", "c")]
        [InlineData("-o", "c", "-s")]
        [InlineData("-s", "-o", "c", "-d", "1")]
        [InlineData("-s", "--order-by", "c", "-d", "1", "-o", "a")]
        public void Parse_OrderByDateOfCreation_OrderByDateOfCreation(params string[] args)
        {
            Options options;

            Parser.Parse(args, out options);

            Assert.True(options.sorting.OrderByDateOfCreation);
            Assert.False(options.WasError);
        }
    }
}
