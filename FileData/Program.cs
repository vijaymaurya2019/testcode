using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using System.Text.RegularExpressions;


namespace FileData
{
    public static class Program
    {
       
        public static void Main(string[] args)
        {
            Console.WriteLine(FileProcessing(args));
            Console.ReadLine();
        }

        public static string FileProcessing(string[] args)
        {
            string message = string.Empty;
            try
            {
                FileProcessing objProcess = new FileProcessing(args);
                message= objProcess.PopulateFileData();
               
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

       
    }
}
