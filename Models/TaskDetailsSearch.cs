using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Education.TodoManager.Models
{
    public class TaskDetailsSearchItem:SearchResultItem
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime DateDue { get; set; }
        public string Details { get; set; }
    }
}