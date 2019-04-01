using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Configuration;

namespace FileData
{
    class FileData
    {
        string _Function;
        string _FileName;
        int ArgsLength;
        string[] VersionArgsArr;
        string[] SizeArgsArr = new string[4];
        string errorMsgNumOfArguments;
        string errorMsgInvalidVersionOrSize;
        string errorMsgInvalidFilePath;
        public FileData(string[] args)
        {
            ArgsLength = args.Length;
            _Function = args[0];  
            _FileName = args[1];


            VersionArgsArr = ConfigurationManager.AppSettings["VersionArgsArr"].Split(',');
            //VersionArgsArr = new string[]{ "-v", "--v", "/v", "-version" };
            SizeArgsArr = ConfigurationManager.AppSettings["SizeArgsArr"].Split(',');
            errorMsgNumOfArguments = "Incorrect number of Arguments supplied.";
            errorMsgInvalidVersionOrSize = "Please provide correct version or size arguments";
            errorMsgInvalidFilePath = "Incorrect file path specified.";

        }

        //validate if version or size text is provided...
        private Boolean ValidateFunctionArgs()
        {
           
            if (VersionArgsArr.Contains(_Function))
                return true;
            else if (SizeArgsArr.Contains(_Function))
                return true;
            else
                return false;
        }
        
        //Validate if correct file Path is provided
        private Boolean ValidatePath()
        {
            string ErrorMessage = string.Empty;
            Regex r = new Regex(@"^([a-zA-Z]:/)([a-z_\-\s0-9\.]+)+\.(txt)$");
            Boolean x = r.IsMatch(_FileName);
            return x;
        }

        //Check for which functionality method to call version, size
        public string CheckForfunctionalityCall()
        {
            string versionOrSize = string.Empty;
            if (VersionArgsArr.Contains(_Function))
                versionOrSize = "v";
            else if (SizeArgsArr.Contains(_Function))
                versionOrSize = "s";
            return versionOrSize;

           
        }
        public string ValidateArgs()
        {
            string errMessage = string.Empty;
            
            if (ArgsLength!=2)
                errMessage = errorMsgNumOfArguments;

            if (!ValidateFunctionArgs())
                errMessage=errorMsgInvalidVersionOrSize;

           if (!ValidatePath())
                errMessage = errorMsgInvalidFilePath ;

            return errMessage;
         }
       
    }
}
