using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Models
{
    public class MyTecBitsDBContext : DbContext
    {
        public MyTecBitsDBContext()
            : base("name=DefaultConnnection")
        {

        }
        public DbSet<MTB_Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}