using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace myTree.Tests
{
    public class PrinterTests
    {
        [Fact]
        public void Print_badArgs_badArgs()
        {
            List<string> actual = new List<string>();
            List<string> expected = new List<string>();
            expected.Add("Bad args");
            expected.Add("use --help");
            Options options;
            string[] args = new string[] { "-2d" };
            Parser.Parse(args, out options);

            Printer.Print(ref options);
            Assert.True(actual.SequenceEqual(expected));
        }
    }
}
