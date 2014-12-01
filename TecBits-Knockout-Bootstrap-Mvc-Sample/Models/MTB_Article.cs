using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Models
{
    public class MTB_Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Level Level { get; set; }
    }
}