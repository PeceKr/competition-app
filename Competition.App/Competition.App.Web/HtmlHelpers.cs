using System.Web.Helpers;

namespace Competition.App.Web
{
    public class HtmlHelpers
    {
        public static string GetAntiForgeryToken()
        {
            string cookieToken, formToken;
            AntiForgery.GetTokens(null, out cookieToken, out formToken);
            return cookieToken + "," + formToken;
        }
    }
}