using System.Collections.Generic;

namespace myTree
{
    public class Parser
    {

        public bool wasError;
        public int depth = -1;
        public bool needSize;
        public bool needHumanReadable;
        public bool needHelp;

        public bool orderBySize;
        public bool orderByDateOfTransorm;
        public bool orderByDateOfCreation;
        public bool orderReverse;

        public bool needInt;
        public bool needFlag;

        public List<string> availableCommands = new List<string>() {
            "-d" , "--depth",
            "-s" , "--size",
            "-h" , "--human-readable" ,
            "-o" , "--order-by" ,
            "-r" , "--reverse" ,
            "--help"
        };

        public List<string> availableSortingFlags = new List<string>() {
            "t",
            "c",
            "s"
        };
        public void ParseArgs(string[] args)
        {
            if (args == null)
            {
                return;
            }

            for (int i = 0; i < args.Length && (wasError != true); i++)
            {
                if (availableCommands.Contains(args[i]))
                {
                    IdentifyCommand(args[i]);
                    continue;
                }
                if (needFlag && (availableSortingFlags.Contains(args[i])))
                {
                    needFlag = false;
                    IdentifySortingFlag(args[i]);
                    continue;
                }
                if (needInt && (int.TryParse(args[i], out int n)))
                {
                    needInt = false;
                    depth = n;
                    continue;
                }
                wasError = true;
            }
        }

        public void IdentifyCommand(string arg)
        {
            switch (arg)
            {
                case "-d":
                case "--depth":
                    needInt = true;
                    break;
                case "-s":
                case "--size":
                    needSize = true;
                    break;
                case "-h":
                case "--human-readable":
                    needHumanReadable = true;
                    break;
                case "--help":
                    needHelp = true;
                    break;
                case "-o":
                case "--order-by":
                    needFlag = true;
                    break;
                case "-r":
                case "--reverse":
                    orderReverse = true;
                    break;
            }
        }

        public void IdentifySortingFlag(string arg)
        {
            switch (arg)
            {
                case "s":
                    orderBySize = true;
                    break;
                case "t":
                    orderByDateOfTransorm = true;
                    break;
                case "c":
                    orderByDateOfCreation = true;
                    break;
            }
        }
        public void Parse(string[] args, out Options options)
        {
            ParseArgs(args);

            if ((needInt) | (needFlag))
            {
                wasError = true;
            }

            options = new Options(
                wasError,
                needSize,
                needHumanReadable,
                needHelp,
                depth,
                orderBySize,
                orderByDateOfTransorm,
                orderByDateOfCreation,
                orderReverse
            );
        }
        public Parser()
        {
            wasError = false;
            depth = -1;
            needSize = false;
            needHumanReadable = false;
            needHelp = false;

            orderBySize = false;
            orderByDateOfTransorm = false;
            orderByDateOfCreation = false;
            orderReverse = false;
        }
    }
}