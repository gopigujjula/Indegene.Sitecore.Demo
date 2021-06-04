using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    public class HeaderNavigationModel
    {
        public List<NavigationModel> TopNavigations { get; set; }
    }
    public class NavigationModel
    {
        public string NavigationTitle { get; set; }
        public string NavigationLink { get; set; }
        public string ActiveClass { get; set; }
    }
}