using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Models
{
    public class ArticleSearchResult
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Excerpt { get; set; }
        public int PageRank { get; set; }
    }
}