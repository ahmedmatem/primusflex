namespace MVCTemplate.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}