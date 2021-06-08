using Indegene.Sitecore.Demo.MVC.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitecoreKernel = Sitecore;
using Sitecore.Data.Items;
using Sitecore.ContentSearch.Linq.Utilities;

namespace Indegene.Sitecore.Demo.MVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult BookDetails()
        {
            return View("~/Views/Builderz/BookDetails.cshtml");
        }
        public ActionResult BookList()
        {
            var startitemPath = SitecoreKernel.Context.Site.StartPath;
            var homeItem = SitecoreKernel.Context.Database.GetItem(startitemPath);
            
            SitecoreIndexableItem contextItem = homeItem;

            SearchResults<CustomBookSearchResultItem> results;
            using (var context = ContentSearchManager.GetIndex(contextItem).CreateSearchContext())
            {    
                IQueryable<CustomBookSearchResultItem> query = context.GetQueryable<CustomBookSearchResultItem>();
                query = query.Where(f => f.Paths.Contains(SitecoreKernel.Context.Item.ID)
                  && f.TemplateId == new SitecoreKernel.Data.ID("{C77CBF36-E660-4C1A-AB94-85F172CA180A}")
                  && f.Language == SitecoreKernel.Context.Language.Name).Page(0, 30);

                //var locationFilter = PredicateBuilder.True<CustomBookSearchResultItem>();
                //if (true)
                //{
                //    locationFilter = locationFilter.And(x => x.Paths.Contains(SitecoreKernel.Context.Item.ID));
                //}
                //query = query.Where(locationFilter);

                //var templateFilter = PredicateBuilder.True<CustomBookSearchResultItem>();
                //for (int i = 0; i < 3; i++)
                //{
                //    templateFilter = templateFilter.Or(x => x.TemplateId
                //    == new SitecoreKernel.Data.ID("{C77CBF36-E660-4C1A-AB94-85F172CA180A}"));
                //}
                //query = query.Where(templateFilter);

                //query = query.Page(0, 30);
                results = query.GetResults();
            }
            List<CustomBookSearchResultItem> resultItems = results?.Hits.Select(f => f.Document).ToList();

            List<BookItem> bookItems = new List<BookItem>();

            foreach (var bookItem in resultItems)
            {
                bookItems.Add(new BookItem()
                {
                    // Book = bookItem.GetItem(),                   
                    Title = bookItem.Title,
                    Summary = bookItem.Summary,
                    Publisher = bookItem.Publisher,
                    PublishedDate = bookItem.PublishedDate,
                    AuthorName = bookItem.AuthorName
                });
            }
            BookSearchResult model = new BookSearchResult()
            {
                Books = bookItems
            };
            
            return View("~/Views/Builderz/BookList.cshtml",model);
        }
    }
}