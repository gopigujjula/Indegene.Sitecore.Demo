using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Globalization;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    public class GlassBase
    {
        [SitecoreId]
        public Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        public string Url { get; set; }
        
        [SitecoreInfo(SitecoreInfoType.Name)]
        string ItemName { get; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language { get; }
    }
}