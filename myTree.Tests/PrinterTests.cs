using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace myTree.Tests
{
    public class PrinterTests
    {
        public string path = "./test";
        public StringCompareShould opt = StringCompareShould.IgnoreCase;

        [Fact]
        public void Print_badArgs_badArgs()
        {
            string[] args = new string[] { "-2d" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Help_Help()
        {
            string[] args = new string[] { "--help" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_noArgs_myTreeWithoutArgs()
        {
            string[] args = new string[] { };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Size_Size()
        {
            string[] args = new string[] { "-s" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_HumanReadable_HumanReadable()
        {
            string[] args = new string[] { "-h" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Depth1_Depth1()
        {
            string[] args = new string[] { "-d", "1" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByAlphabet_OrderByAlphabet()
        {
            string[] args = new string[] { };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByAlphabetRevert_OrderByAlphabetRevert()
        {
            string[] args = new string[] { "-r" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderBySize_OrderBySize()
        {
            string[] args = new string[] { "-o", "s", "-s" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderBySizeReverse_OrderBySizeReverse()
        {
            string[] args = new string[] { "-o", "s", "-s", "-r" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByDateOfCreation_OrderByDateOfCreation()
        {
            string[] args = new string[] { "-o", "c" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByDateOfTransform_OrderByDateOfTransform()
        {
            string[] args = new string[] { "-o", "t" };
            var ls = new StringWriter();
            var alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.str.ToString().ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }
    }
}
