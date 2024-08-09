using System.Web.Mvc;

namespace BRANDEXCL.Areas.Outlet
{
    public class OutletAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Outlet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Outlet_default",
                "Outlet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}