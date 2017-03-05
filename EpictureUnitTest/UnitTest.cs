using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using DotNet_epicture_2016;
using System.Net.Http;

namespace EpictureUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ImgurAPI api = new ImgurAPI();

        [TestMethod]
        public void TestMethod1()
        {
            HttpContent content = api.getImages("pepe", 0, 0, "png", 1);
            Assert.AreNotEqual(content, null); 
        }
    }
}
