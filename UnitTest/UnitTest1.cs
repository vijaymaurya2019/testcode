using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
using System.Text.RegularExpressions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
 // test method for different file version format ------------------------------------------------
        [TestMethod]
        public void TestVersion1()
        {
            string[] data = { "-v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
           
            
        }
        [TestMethod]
        public void TestVersion2()
        {
            string[] data = { "--v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersion3()
        {
            string[] data = { "/v", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }
        [TestMethod]
        public void TestVersion4()
        {
            string[] data = { "-version", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Version"));
        }

        [TestMethod]
        public void TestVersion5()
        {
            string[] data = { "xx", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(!result.Contains("Version"));
        }

        //-----------------------------------------------------------------------------------//
        // test method for different file size format......
        [TestMethod]
        public void TestSize1()
        {
            string[] data = { "-s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize2()
        {
            string[] data = { "--s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize3()
        {
            string[] data = { "/s", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }
        [TestMethod]
        public void TestSize4()
        {
            string[] data = { "-size", "c:/test.txt" };
            string result = Program.FileProcessing(data);
            Assert.IsTrue(result.Contains("Size"));
        }

        
    }
}
