using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitecoreKernel = Sitecore;

namespace Indegene.Sitecore.Demo.MVC.Controllers
{
    public class BuilderzSearchController : Controller
    {
        // GET: BuilderzSearch
        public ActionResult Index()
        {
            SearchResults<SearchResultItem> results;
            using (var context = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
            {
                var query = context.GetQueryable<SearchResultItem>();
                query = query.Where(f =>
                     f.Paths.Contains(new SitecoreKernel.Data.ID("{19D4B8E2-E034-48FA-94C0-F0942CACF2B1}"))
                  && f.TemplateId == new SitecoreKernel.Data.ID("{C0A3D3FE-464E-439C-9EAA-0564CC6952DE}")
                  && f.Language == SitecoreKernel.Context.Language.Name
                  && f.Content.Contains("about")).Page(0, 20);

                results = query.GetResults();
            }

            if (results != null && results.TotalSearchResults > 0)
            {
                List<SearchResultItem> resultItems = results.Hits.Select(f => f.Document).ToList();
            }
            return View();
        }
    }
}