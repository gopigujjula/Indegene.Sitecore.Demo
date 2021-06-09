using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indegene.Sitecore.Demo.MVC.Models;
using Sitecore.Kernel;
using SitecoreKernel = Sitecore;
using Sitecore.Data.Items;
using Sitecore.Links.UrlBuilders;
using Sitecore.Mvc.Presentation;

namespace Indegene.Sitecore.Demo.MVC.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult HeaderNavigation()
        {
            var model = new HeaderNavigationModel();
            List<NavigationModel> navigations = new List<NavigationModel>();

            //read a tree // build a navigation
            var startitemPath = SitecoreKernel.Context.Site.StartPath;
            var homeItem = SitecoreKernel.Context.Database.GetItem(startitemPath);
            navigations.Add(GetNavigation(homeItem));

            if (homeItem.HasChildren)
            {
                foreach (Item child in homeItem.Children)
                {
                    navigations.Add(GetNavigation(child));
                }
            }
            model.TopNavigations = navigations;

            return View("~/Views/Builderz/HeaderNavigation.cshtml", model);
        }

        public NavigationModel GetNavigation(Item item)
        {
            
            if (item != null)
            {
                DefaultItemUrlBuilderOptions defaultItemUrlBuilderOptions = new DefaultItemUrlBuilderOptions();                
                ItemUrlBuilder itemUrlBuilder = new ItemUrlBuilder(defaultItemUrlBuilderOptions);

                return new NavigationModel()
                {
                    NavigationTitle = item.Fields["NavigationTitle"]?.Value,
                    NavigationLink = itemUrlBuilder.Build(item, defaultItemUrlBuilderOptions),
                    ActiveClass = PageContext.Current.Item.ID == item.ID ? "active" : string.Empty                    
                };
            }
            return null;
        }
    }
}