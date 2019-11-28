using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Functions.Task2
{
    [TestClass]
    public class SitePageTest
    {
        [TestMethod]
        public void Should_GenerateUrl_With_EmptyParams()
        {
            Assert.AreEqual("http://mysite.com/?edit=true&siteGrp=default&userGrp=admin",
                    new SitePage("default", "admin").GetEditablePageUrl(new Dictionary<string, string>()));
        }

        [TestMethod]
        public void Should_GenerateUrl_With_SeveralParams()
        {
            Assert.AreEqual("http://mysite.com/?edit=true&id=1234&user=Alex&redirect=true&siteGrp=mySite&userGrp=std",
                    new SitePage("mySite", "std").GetEditablePageUrl(new Dictionary<string, string> { { "id", "1234" }, { "user", "Alex" }, { "redirect", "true" } }));
        }
    }
}