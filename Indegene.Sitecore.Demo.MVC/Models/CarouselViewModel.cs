using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    public class CarouselViewModel
    {
        public string DatasourcePath { get; set; }
        public List<Slide> Slides { get; set; }
    }

    public class Slide
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString SubTitle { get; set; }
        public MvcHtmlString BackgroundImage { get; set; }
        public MvcHtmlString Link { get; set; }
        public string Style { get; set; }
    }
}