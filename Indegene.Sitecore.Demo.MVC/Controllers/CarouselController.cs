using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Indegene.Sitecore.Demo.MVC.Models;

namespace Indegene.Sitecore.Demo.MVC.Controllers
{
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            var model = new CarouselViewModel();
            var slides = new List<Slide>();

            //read page item
            //var item = PageContext.Current.Item;

            //read datasource item
            var item = RenderingContext.Current?.Rendering.Item;

            //Rendering parameters
            var slideCountParameter = RenderingContext.Current?.Rendering.Parameters["slidecount"];
            int.TryParse(slideCountParameter, out int result);
            int slideCount = result == 0 ? 3 : result;

            if (item != null)
            {
                MultilistField sliderField = item.Fields["Slides"];

                if (sliderField?.Count > 0)
                {
                    var slideItems = sliderField.GetItems();
                    foreach (var slideItem in slideItems.Take(slideCount))
                    {
                        slides.Add(
                            new Slide
                            {
                                Title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Title")),
                                SubTitle = new MvcHtmlString(FieldRenderer.Render(slideItem, "Subtitle")),
                                BackgroundImage = new MvcHtmlString(FieldRenderer.Render(slideItem, "BackgroundImage")),
                                Link = new MvcHtmlString(FieldRenderer.Render(slideItem, "Link","class=btn animated fadeInUp")),
                                Style = slideItems.First()?.ID == slideItem.ID ? "active" : string.Empty
                            });
                    }
                    model.Slides = slides;
                }
            }
            return View("~/Views/Builderz/CarouselSlider.cshtml", model);
        }
    }
}