using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}