using System;
using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Indegene.Sitecore.Demo.MVC.Models
{
    public class BookSearchResult
    {
        public List<BookItem> Books { get; set; }
    }

    public class BookItem
    {
        public Item Book { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }        
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorName { get; set; }
    }    
}