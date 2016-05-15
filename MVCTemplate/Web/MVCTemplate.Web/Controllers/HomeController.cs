namespace MVCTemplate.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.UserId = this.User.Identity.GetUserId();

            return View();
        }
    }
}