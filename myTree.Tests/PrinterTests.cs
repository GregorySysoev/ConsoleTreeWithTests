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
        ListWriter ls = new ListWriter();
        Algorithm alg;

        [Fact]
        public void Print_badArgs_badArgs()
        {
            string[] args = new string[] { "-2d" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Help_Help()
        {
            string[] args = new string[] { "--help" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_noArgs_myTreeWithoutArgs()
        {
            string[] args = new string[] { };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Size_Size()
        {
            string[] args = new string[] { "-s" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_HumanReadable_HumanReadable()
        {
            string[] args = new string[] { "-h" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_Depth1_Depth1()
        {
            string[] args = new string[] { "-d", "1" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByAlphabet_OrderByAlphabet()
        {
            string[] args = new string[] { "-o", "a" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByAlphabetRevert_OrderByAlphabetRevert()
        {
            string[] args = new string[] { "-o", "a", "-r" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderBySize_OrderBySize()
        {
            string[] args = new string[] { "-o", "s", "-s" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderBySizeReverse_OrderBySizeReverse()
        {
            string[] args = new string[] { "-o", "s", "-s", "-r" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByDateOfCreation_OrderByDateOfCreation()
        {
            string[] args = new string[] { "-o", "c" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }

        [Fact]
        public void Print_OrderByDateOfTransform_OrderByDateOfTransform()
        {
            string[] args = new string[] { "-o", "t" };
            ls = new ListWriter();
            alg = new Algorithm(args, ls, path);

            alg.Execute();

            ls.list.ShouldMatchApproved(c => c.WithStringCompareOptions(opt));
        }
    }
}
