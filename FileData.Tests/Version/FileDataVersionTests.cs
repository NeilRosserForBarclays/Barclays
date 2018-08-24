using NUnit.Framework;

namespace FileData.Tests
{
    [TestFixture]
    public class FileDataVersionTests
    {
        //SUT
        IWrapper thirdPartyToolsWrapper;

        string filename;

        [SetUp]
        protected void SetUp()
        {
            thirdPartyToolsWrapper = new FileDetailsExtended();
            filename = "somefilename";
        }

        [Test]
        public void ValidVersionActionReturnsValidString([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = thirdPartyToolsWrapper.Action<string>(actionParameter, filename);
            Assert.AreNotEqual(default(string), result); 
        }

        [Test]
        public void ValidVersionActionReturnsMinimumStringLength([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = thirdPartyToolsWrapper.Action<string>(actionParameter, filename);
            Assert.IsTrue(result.Length > 4);
        }
        [Test]
        public void ValidVersionActionReturnsCorrectFormattedString([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = thirdPartyToolsWrapper.Action<string>(actionParameter, filename);
            Assert.IsTrue(result[1] == '.');
            Assert.IsTrue(result[3] == '.');
        }

        [Test]
        public void InvalidActionReturnsDefault([Values("d", "", "++v")] string actionParameter)
        {
            var result = thirdPartyToolsWrapper.Action<string>(actionParameter, filename);
            Assert.AreEqual(default(string), result);
        }

    }
}