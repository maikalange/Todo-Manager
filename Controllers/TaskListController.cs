using Sitecore.Education.TodoManager.Models;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class TaskListController : Controller
    {
        // GET: TaskList
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        public ActionResult AllTasks()
        {
            return View(CreateModel());
        }

        private List<Task> CreateModel()
        {
            TaskList tasks = new TaskList();
            var items = Context.Database.GetItem("{ED3BC3C1-43DB-4FE3-92CD-066401F1773A}").GetChildren();
            foreach (Data.Items.Item item in items)
            {

                Task t = new Task()
                {
                    Name = new HtmlString(item.Name),
                    Category = new HtmlString(FieldRenderer.Render(item,"category")),
                    Description = new HtmlString(FieldRenderer.Render(item, "description")),
                    Details = new HtmlString(FieldRenderer.Render(item, "details")),
                    DueDate = new HtmlString(FieldRenderer.Render(item, "datedue","format= dd-MM-yy")),
                    Status = new HtmlString(FieldRenderer.Render(item, "status")),
                    Url = new HtmlString(LinkManager.GetItemUrl(item))
                };
                tasks.Add(t);
            }
            return tasks;
        }
    }
}