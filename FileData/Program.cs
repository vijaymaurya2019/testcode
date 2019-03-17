using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using System.Text.RegularExpressions;


namespace FileData
{
    public static class Program
    {
        public static Boolean isValid =true;
        public static void Main(string[] args)
        {
            ValidateArgs(args);  //validate arguments...    

            if (isValid)
            {
                FileDetails obj = new FileDetails(); //Call to thirdParty class
                string versionorSize = CheckForfunctionalityCall(args[0].ToString());
                if (versionorSize==ApplicationConstants.versionText)
                    Console.WriteLine("Version : " + obj.Version(args[1]));       //Call to third party version method
                else
                    Console.WriteLine("Size : " + obj.Size(args[1]));             //Call to third party size method
            }
            Console.ReadLine();
        }

        //Check for which functionality method to call version, size
        private static string CheckForfunctionalityCall(string info)
        {
            string versionOrSize = string.Empty;
            if (ApplicationConstants.VersionArgsArr.Contains(info))
                versionOrSize = ApplicationConstants.versionText;
            else if (ApplicationConstants.SizeArgsArr.Contains(info))
                versionOrSize = ApplicationConstants.SizeText;
            return versionOrSize;
        }

        //Validate number and correct format of arguments..
        private static void ValidateArgs(string[] args)
        {
            string versionorSize, FileName;

            if (args.Length != 2)
            {
                Console.WriteLine(ApplicationConstants.errorMsgNumOfArguments);
                isValid = false;
                return;
            }

            versionorSize = args[0];
            FileName = args[1];

            if (!ValidateFunctionArgs(versionorSize))
            {
                Console.WriteLine(ApplicationConstants.errorMsgInvalidVersionOrSize);
                isValid = false;
                return;
            }

            if (!ValidatePath(FileName))
            {
                Console.WriteLine(ApplicationConstants.errorMsgInvalidFilePath);
                isValid = false;
                return;
            }
           
        }

        //validate if version or size text is provided...
        private static Boolean ValidateFunctionArgs(string info)
        {
            if (ApplicationConstants.VersionArgsArr.Contains(info))
                return true;
            else if (ApplicationConstants.SizeArgsArr.Contains(info))
                return true;
            else
                return false;
       }

        //Validate if correct file Path is provided
        public static bool ValidatePath(string FileName)
        {
            string ErrorMessage = string.Empty;
            Regex r = new Regex(@"^([a-zA-Z]:/)([a-z_\-\s0-9\.]+)+\.(txt)$");
            Boolean x = r.IsMatch(FileName);
            return x;
        }
       
    }
}
