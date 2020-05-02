using System;
using System.Web;

namespace Sitecore.Education.TodoManager.Models
{
    public class Task
    {
        public DateTime DueDate { get; set; }
        public HtmlString Description { get; set; }
        public HtmlString Category { get; set; }
        public HtmlString Status { get; set; }
        public HtmlString Details { get; set; }
        public HtmlString Url { get; internal set; }
    }
}