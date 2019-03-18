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
            Console.WriteLine(PopulateFileData(args));
            Console.ReadLine();
        }

        public static string PopulateFileData(string[] args)
        {
            string Message = string.Empty;
            string versionorSize = string.Empty;

            if (args.Length != 2)
            {
                Message = ApplicationConstants.errorMsgNumOfArguments;
                return Message;
            }

            try
            {
                FileData objFileData = new FileData(args[0], args[1]);
                Message = objFileData.ValidateArgs();  //validate arguments...

                if (String.IsNullOrEmpty(Message))
                {
                    versionorSize = objFileData.CheckForfunctionalityCall();
                    //Call to thirdParty class
                    FileDetails objFileDetails = new FileDetails();
                    if (versionorSize == ApplicationConstants.versionText)
                        //Call to third party version method
                        Message = "Version" + objFileDetails.Version(args[1]);
                    else
                        //Call to Size method
                       Message= "Size" + objFileDetails.Size(args[1]);
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }

            return Message;
        }
    }
}
