using System.Collections.Generic;
using System.Text;

namespace Functions.Task2
{
    public class SitePage
    {
        private const string Http = "http://";
        private const string Editable = "/?edit=true";
        private const string Domain = "mysite.com";

        public string SiteGroup { get; }
        public string UserGroup { get; }

        public SitePage(string siteGroup, string userGroup)
        {
            SiteGroup = siteGroup;
            UserGroup = userGroup;
        }

        public string GetEditablePageUrl(IDictionary<string, string> parameters)
        {
            var paramsString = new StringBuilder();
            foreach (var parameter in parameters)
            {
                paramsString.Append($"&{parameter.Key}={parameter.Value}");
            }

            return Http + Domain + Editable + paramsString + GetAttributes();
        }

        private string GetAttributes()
        {
            return $"&siteGrp={SiteGroup}&userGrp={UserGroup}";
        }
    }
}