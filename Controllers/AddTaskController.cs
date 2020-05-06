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
            ViewBag.Status = Context.Database.GetItem("{499D7705-DD88-44E0-B352-43E46FD16FCB}").GetChildren();
            ViewBag.Category = Context.Database.GetItem("{D3D68F62-061B-4847-ACC4-CA1109EAA718}").GetChildren();
            return View();
        }


    }
}