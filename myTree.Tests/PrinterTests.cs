using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace myTree.Tests
{
    public class PrinterTests
    {
        public string path = "/home/gregory/var/test/";

        [Fact]
        public void Print_badArgs_badArgs()
        {
            List<string> expected = new List<string>();
            expected.Add("Bad args");
            expected.Add("use --help");
            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-2d" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_Help_Help()
        {
            List<string> expected = new List<string>();
            expected.Add("");
            expected.Add("List of available commands:");
            expected.Add("");
            expected.Add("-d --depth [num]  nesting level");
            expected.Add("-s --size  show size of files");
            expected.Add("-h --human-readable  show size of files in human-readable view {Bytes, KB, ...}");
            expected.Add("-o --order-by [flag] order of elements in tree");
            expected.Add("");
            expected.Add("Available flags:");
            expected.Add("a - order by alphabet");
            expected.Add("s - order by size");
            expected.Add("t - order by time of last change");
            expected.Add("c - order by time of creation");
            expected.Add("");

            expected.Add("--help show help");
            expected.Add("");
            expected.Add("Example of using:");
            expected.Add("dotnet myTree.dll -d 5 -h -o a");
            expected.Add("");
            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "--help" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_noArgs_myTreeWithoutArgs()
        {
            List<string> expected = new List<string>();
            expected.Add("├──myTree.runtimeconfig.json");
            expected.Add("├──txt");
            expected.Add("│   ├──helloworld");
            expected.Add("│   └──byeworld");
            expected.Add("├──tmp");
            expected.Add("│   ├──helloworld");
            expected.Add("│   ├──123");
            expected.Add("│   │   ├──helloworld");
            expected.Add("│   │   └──byeworld");
            expected.Add("│   └──byeworld");
            expected.Add("├──test");
            expected.Add("├──app");
            expected.Add("└──myTree.dll");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_Size_Size()
        {
            List<string> expected = new List<string>();
            expected.Add("├──myTree.runtimeconfig.json (146 Bytes)");
            expected.Add("├──txt");
            expected.Add("│   ├──helloworld (empty)");
            expected.Add("│   └──byeworld (empty)");
            expected.Add("├──tmp");
            expected.Add("│   ├──helloworld (37 Bytes)");
            expected.Add("│   ├──123");
            expected.Add("│   │   ├──helloworld (empty)");
            expected.Add("│   │   └──byeworld (empty)");
            expected.Add("│   └──byeworld (35 Bytes)");
            expected.Add("├──test");
            expected.Add("├──app");
            expected.Add("└──myTree.dll (12800 Bytes)");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-s" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_HumanReadable_HumanReadable()
        {
            List<string> expected = new List<string>();
            expected.Add("├──myTree.runtimeconfig.json (146 Bytes)");
            expected.Add("├──txt");
            expected.Add("│   ├──helloworld (empty)");
            expected.Add("│   └──byeworld (empty)");
            expected.Add("├──tmp");
            expected.Add("│   ├──helloworld (37 Bytes)");
            expected.Add("│   ├──123");
            expected.Add("│   │   ├──helloworld (empty)");
            expected.Add("│   │   └──byeworld (empty)");
            expected.Add("│   └──byeworld (35 Bytes)");
            expected.Add("├──test");
            expected.Add("├──app");
            expected.Add("└──myTree.dll (12,5 KB)");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-h" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_Depth1_Depth1()
        {
            List<string> expected = new List<string>();
            expected.Add("├──myTree.runtimeconfig.json");
            expected.Add("├──txt");
            expected.Add("├──tmp");
            expected.Add("├──test");
            expected.Add("├──app");
            expected.Add("└──myTree.dll (12,5 KB)");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-d", "1", "-h" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        [Fact]
        public void Print_OrderByAlphabet_OrderByAlphabet()
        {
            List<string> expected = new List<string>();
            expected.Add("├──app");
            expected.Add("├──myTree.dll");
            expected.Add("├──myTree.runtimeconfig.json");
            expected.Add("├──test");
            expected.Add("├──tmp");
            expected.Add("│   ├──123");
            expected.Add("│   │   ├──byeworld");
            expected.Add("│   │   └──helloworld");
            expected.Add("│   ├──byeworld");
            expected.Add("│   └──helloworld");
            expected.Add("└──txt");
            expected.Add("   ├──byeworld");
            expected.Add("   └──helloworld");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-o", "a" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }

        public void Print_OrderBySize_OrderBySize()
        {
            List<string> expected = new List<string>();
            expected.Add("├──txt");
            expected.Add("│   ├──helloworld (empty)");
            expected.Add("│   └──byeworld (empty)");
            expected.Add("├──tmp");
            expected.Add("│   ├──123");
            expected.Add("│   │   ├──helloworld (empty)");
            expected.Add("│   │   └──byeworld (empty)");
            expected.Add("│   ├──byeworld (35 Bytes)");
            expected.Add("│   └──helloworld (37 Bytes)");
            expected.Add("├──test");
            expected.Add("├──app");
            expected.Add("├──myTree.runtimeconfig.json (146 Bytes)");
            expected.Add("└──myTree.dll (12800 Bytes)");
            expected.Add("");

            Options options;
            ListWriter lw = new ListWriter();
            List<string> actual = lw.list;
            string[] args = new string[] { "-o", "s", "-s" };

            Parser.Parse(args, out options);
            Printer.Print(ref options, lw, path);
            Assert.True(actual.SequenceEqual(expected));
        }
    }
}
