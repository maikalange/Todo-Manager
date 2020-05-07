﻿using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Education.TodoManager.Models;
using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int pageNo=0)
        {
            return View(GetEventsList(string.Empty,pageNo));
        }
        [HttpPost]
        public ActionResult Index(int pageNo=0,string searchTerm="")
        {
            return View(GetEventsList(searchTerm, pageNo));
        }
        private const int PageSize = 10;
        public SearchResultsList GetEventsList(string searchTerm,int pageNo)
        {
            ViewBag.SearchTerm = searchTerm;
            var indexname = $"todo_{RenderingContext.Current.ContextItem.Database.Name.ToLower()}_index";
            var index = ContentSearchManager.GetIndex(indexname);
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<TaskDetailsSearchItem>()
                    .Where(t=>t.Category=="Domestic")
                .Page(pageNo, PageSize)
                .GetResults();
                ViewBag.TotalResultCount = results.TotalSearchResults;
                 var x =new SearchResultsList()
                {
                    Tasks = results.Hits.Select(h => h.Document).ToArray(),
                    PageSize = PageSize,
                    TotalResultCount = results.TotalSearchResults
                };
                return x;
            }
        }
    }
}