
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Education.TodoManager.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Education.TodoManager.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            //Get the index
            //Create a search context and then perform the search
    
            return View();
        }
        private const int PageSize = 4;
        public SearchResultsList GetEventsList(int pageNo)
        {
            var indexname =
            $"todo_{RenderingContext.Current.ContextItem.Database.Name.ToLower()}_index";
        var index = ContentSearchManager.GetIndex(indexname);
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<TaskDetailsSearchItem>()
                .Where(i =>
                i.Paths.Contains(RenderingContext.Current.ContextItem.ID))
                .Where(i => i.Language ==
                RenderingContext.Current.ContextItem.Language.Name)
                .Page(pageNo, PageSize)
                .GetResults();
                return new SearchResultsList()
                {
                    Tasks = results.Hits.Select(h => h.Document).ToArray(),
                    PageSize = PageSize,
                    TotalResultCount = results.TotalSearchResults
                };
            }
        }
    }
}