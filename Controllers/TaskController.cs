﻿using Sitecore.Education.TodoManager.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            var item = RenderingContext.Current.ContextItem;
            Task t = new Task()
            {
                Category = new HtmlString(FieldRenderer.Render(item, "category")),
                Name = new HtmlString(item.Name),
                Description = new HtmlString(FieldRenderer.Render(item, "description")),
                Details = new HtmlString(FieldRenderer.Render(item, "details")),
                DueDate = new HtmlString(FieldRenderer.Render(item, "datedue","format=dd-MM-yy")),
                Status = new HtmlString(FieldRenderer.Render(item, "status")),
                Url = new HtmlString(LinkManager.GetItemUrl(item))
            };
            return View(t);
        }
    }
}