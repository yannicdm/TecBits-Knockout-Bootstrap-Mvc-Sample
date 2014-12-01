using System.Web;
using System.Web.Mvc;
using Elmah.Contrib.Mvc;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // filters.Add(new HandleErrorAttribute());
            filters.Add(new ElmahHandleErrorAttribute());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector),
             new NamespaceHttpControllerSelector(GlobalConfiguration.Configuration));
        }
    }
}