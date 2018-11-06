using System.Web;
using System.Web.Mvc;

namespace CRUD_Productos_Semana11_NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
