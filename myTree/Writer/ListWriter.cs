using myTree;
using System;
using System.Collections;
using System.Collections.Generic;

namespace myTree
{
    public class ListWriter : IWriter
    {
        public string list;
        public void Write(string text)
        {
            list += text;
        }
        public void WriteLine()
        {
            list += "\n";
        }

        public void WriteLine(string text)
        {
            list += text += "\n";
        }

        public ListWriter()
        {
            list = "";
        }
    }
}