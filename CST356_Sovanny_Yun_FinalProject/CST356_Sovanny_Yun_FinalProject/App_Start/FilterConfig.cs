using System.Web;
using System.Web.Mvc;

namespace CST356_Sovanny_Yun_FinalProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
