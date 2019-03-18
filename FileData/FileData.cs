using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileData
{
    class FileData
    {
        string _Function;
        string _FileName;
        public FileData(string Function, string FileName)
        {
            _Function = Function;
            _FileName = FileName;
        }

        //validate if version or size text is provided...
        private Boolean ValidateFunctionArgs()
        {
            if (ApplicationConstants.VersionArgsArr.Contains(_Function))
                return true;
            else if (ApplicationConstants.SizeArgsArr.Contains(_Function))
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
            if (ApplicationConstants.VersionArgsArr.Contains(_Function))
                versionOrSize = ApplicationConstants.versionText;
            else if (ApplicationConstants.SizeArgsArr.Contains(_Function))
                versionOrSize = ApplicationConstants.SizeText;
            return versionOrSize;

           
        }
        public string ValidateArgs()
        {
            string errMessage = string.Empty;

            if (!ValidateFunctionArgs())
                errMessage= ApplicationConstants.errorMsgInvalidVersionOrSize;

           if (!ValidatePath())
                errMessage = ApplicationConstants.errorMsgInvalidFilePath ;

            return errMessage;
         }
    }
}
