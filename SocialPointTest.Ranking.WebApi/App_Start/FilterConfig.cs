using System.Web;
using System.Web.Mvc;

namespace SocialPointTest.Ranking.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
