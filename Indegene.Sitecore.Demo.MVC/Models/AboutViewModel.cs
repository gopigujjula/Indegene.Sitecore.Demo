using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    public class AboutViewModel
    {
        public Item DataSourceItem { get; set; }
        public string Title { get; set; }
        public MvcHtmlString SubTitle { get; set; }
    }
}