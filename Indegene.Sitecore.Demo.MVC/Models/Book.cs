using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    [SitecoreType(TemplateId = "{C77CBF36-E660-4C1A-AB94-85F172CA180A}")]
    public class Book : GlassBase
    {
        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Description")]
        public virtual string Description { get; set; }

        [SitecoreField("Front Cover")]
        public virtual Image FrontCover { get; set; }
        
        [SitecoreField("Book Language Link")]
        public virtual BookTaxonomy BookLanguage { get; set; }
        
        [SitecoreField("Author")]
        public virtual IEnumerable<Author> Authors { get; set; }
    }

    [SitecoreType(TemplateId = "{F09E9CB8-5FE1-4036-8D37-F810137CD30F}")]
    public class BookTaxonomy:GlassBase
    {
        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Description")]
        public virtual string Description { get; set; }
    }

    [SitecoreType(TemplateId = "{2E7CB92B-8A6A-468E-BB55-B8AEA2701EC5}")]
    public class Author : GlassBase
    {
        [SitecoreField("First Name")]
        public virtual string FirstName { get; set; }
    }

}