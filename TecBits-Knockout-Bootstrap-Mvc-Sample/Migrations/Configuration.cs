namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TecBits_Knockout_Bootstrap_Mvc_Sample.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TecBits_Knockout_Bootstrap_Mvc_Sample.Models.MyTecBitsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TecBits_Knockout_Bootstrap_Mvc_Sample.Models.MyTecBitsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var authors = new List<Author>() { new Author() { Name = "James Boone" } };
            
            authors.ForEach(a => context.Authors.AddOrUpdate(x => x.Name, a));
            context.SaveChanges();
            
            var articles = new List<MTB_Article>() { 
            new MTB_Article() { Title = "The Sopranos", Excerpt = "Modern day morality tale about New Jersey mob boss", Content = "Modern day morality tale about New Jersey mob boss Tony Soprano, as he deals with personal and professional issues in his home and business life.", AuthorId = context.Authors.Single(x => x.Name == "James Boone").Id, Level = Level.A },
             new MTB_Article() { Title = "Game of Thrones", Excerpt = "Fight for control of the mythical land of Westeros", Content = "Seven noble families fight for control of the mythical land of Westeros", AuthorId = context.Authors.Single(x => x.Name == "James Boone").Id, Level = Level.B },
            new MTB_Article() { Title = "Breaking Bad", Excerpt = "A high school chemistry teacher turns to a life of crime", Content = "A high school chemistry teacher turns to a life of crime in order to provide for his family's future", AuthorId = context.Authors.Single(x => x.Name == "James Boone").Id, Level = Level.B }
            };

            articles.ForEach(a => context.Articles.AddOrUpdate(x => x.Title,a));
            context.SaveChanges();
        }
    }
}
