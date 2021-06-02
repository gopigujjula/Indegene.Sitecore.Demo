using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indegene.Sitecore.Demo.MVC.Models;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace Indegene.Sitecore.Demo.MVC.Controllers
{
    public class AboutController : Controller
    {       
        public ActionResult Index()
        {
            //Item, bind to the model, and pass to the view
            var model = new AboutViewModel 
            { 
                DataSourceItem = RenderingContext.Current?.Rendering.Item 
            };
            //Item, read the values, build a model and pass it
            var item = RenderingContext.Current?.Rendering.Item;
            if(item!=null)
            {
                Field title = item.Fields["Title"];
                model.Title = title?.Value;                 
            }
            //Item, read the values using FieldRenderer, build a model and pass it
            model.SubTitle = new MvcHtmlString(FieldRenderer.Render(item, "SubTitle"));
            return View("~/Views/Builderz/About.cshtml", model);
        }
    }
}