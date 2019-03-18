using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
using System.Text.RegularExpressions;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
 // test method for file version------------------------------------------------
        [TestMethod]
        public void TestVersion1()
        {
            string[] data = { "-v", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Regex r = new Regex(@"^(\d.)(\d.)(\d)+$");
            Assert.IsTrue(result.Contains("Version"));
            
        }
        [TestMethod]
        public void TestVersion2()
        {
            string[] data = { "--v", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersion3()
        {
            string[] data = { "/v", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersion4()
        {
            string[] data = { "-version", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }

 //Negative test cases for Version---------------------------------------
        
        //Invalid number of arguments
        [TestMethod]
        public void TestVersion5()
        {
            string[] data = { };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        //Incorrect version and filename format
        [TestMethod]
        public void TestVersion6()
        {
            string[] data = { "v" , "test"};
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }

        //Incorrect version format
        [TestMethod]
        public void TestVersion7()
        {
            string[] data = { "v", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Version"));
        }
//-----------------------------------------------------------------------------------//
        // test method for file size......
        [TestMethod]
        public void TestSize1()
        {
            string[] data = { "-s", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize2()
        {
            string[] data = { "--s", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize3()
        {
            string[] data = { "/s", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize4()
        {
            string[] data = { "-size", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }

        // negative test method for file size---------------------------

        //Incorrect filename format
        [TestMethod]
        public void TestSize5()
        {
            string[] data = { "-s", "test" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }

        //Incorrect size format
        [TestMethod]
        public void TestSize6()
        {
            string[] data = { "s", "c:/test.txt" };
            string result = Program.PopulateFileData(data);
            Assert.IsTrue(result.Contains("Size"));
        }
    }
}
