using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_1_BWT_;

namespace TestProject_1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1()
        {
            (string textEncode, int endPosition) = BWT.TextEncode("banana");
            Assert.AreEqual("nnbaaa", textEncode);
            Assert.AreEqual(3, endPosition);
        }

        [TestMethod]
        public void Test2()
        {
            (string textEncode, int endPosition) = BWT.TextEncode("AAAAA");
            Assert.AreEqual("AAAAA", textEncode);
            Assert.AreEqual(4, endPosition);
        }

        [TestMethod]
        public void Test3()
        {
            (string textEncode, int endPosition) = BWT.TextEncode("ABABA");
            Assert.AreEqual("BBAAA", textEncode);
            Assert.AreEqual(2, endPosition);
        }

        [TestMethod]
        public void Test4()
        {
            (string textEncode, int endPosition) = BWT.TextEncode("A");
            Assert.AreEqual("A", textEncode);
            Assert.AreEqual(0, endPosition);
        }

        [TestMethod]
        public void Test5()
        {
            string textDecode = BWT.TextDecode("nnbaaa", 3);
            Assert.AreEqual("banana", textDecode);
        }


        [TestMethod]
        public void Test6()
        {
            string textDecode = BWT.TextDecode("AAAAA", 4);
            Assert.AreEqual("AAAAA", textDecode);
        }

        [TestMethod]
        public void Test7()
        {
            string textDecode = BWT.TextDecode("BBAAA", 2);
            Assert.AreEqual("ABABA", textDecode);
        }

        [TestMethod]
        public void Test8()
        {
            string textDecode = BWT.TextDecode("A",0);
            Assert.AreEqual("A", textDecode);
        }

        [TestMethod]
        public void Test9()
        {
            string text = "QWERTYUUUUIOPUUU34555DFGUU345";
            (string textEncode, int endPosition) = BWT.TextEncode(text);
            string textDecode = BWT.TextDecode(textEncode, endPosition);
            Assert.AreEqual(text, textDecode);
        }
    }
}