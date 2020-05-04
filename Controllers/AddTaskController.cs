using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class AddTaskController : Controller
    {
        // GET: AddTask
        public ActionResult Index()
        {
            ViewBag.Status = Context.Database.GetItem("/sitecore/content/TODO/Repository/Task Status").GetChildren();
            ViewBag.Category = Context.Database.GetItem("/sitecore/content/TODO/Repository/Task Category").GetChildren();
            return View();
        }


    }
}