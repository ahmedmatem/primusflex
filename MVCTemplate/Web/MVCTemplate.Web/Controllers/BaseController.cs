namespace MVCTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Infrastructure.Mapping;
    using System.Web;
    using Microsoft.AspNet.Identity.Owin;
    public abstract class BaseController : Controller
    {
        protected ApplicationUserManager userManager;

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
    }
}
