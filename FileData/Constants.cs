using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public static class ApplicationConstants
    {
        public static string versionText = "v";
        public static string SizeText = "s";
        public static string[] VersionArgsArr = { "-v", "--v", "/v", "-version" };
        public static string[] SizeArgsArr = { "-s", "--s", "/s", "-size" };
        public static string errorMsgNumOfArguments = "Incorrect number of Arguments supplied.";
        public static string errorMsgInvalidVersionOrSize = "Please provide correct version or size arguments.";
        public static string errorMsgInvalidFilePath = "Incorrect file path specified.";
      
    }
}
