using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Education.TodoManager.Models
{
    public class SearchResultsList
    {
        public IEnumerable<TaskDetailsSearchItem> Tasks { get; set; }
        public int TotalResultCount { get; set; }
        public int PageSize { get; set; }
    }
}