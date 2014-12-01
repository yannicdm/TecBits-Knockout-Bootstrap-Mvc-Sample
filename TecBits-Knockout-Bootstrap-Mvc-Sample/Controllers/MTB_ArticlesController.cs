using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TecBits_Knockout_Bootstrap_Mvc_Sample.Models;
using NLog;
using System.Web.UI.WebControls;
using AutoMapper;
using SmartFormat;


namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Controllers
{

    public class MTB_ArticlesController : Controller
    {
        private MyTecBitsDBContext _ctx;

        public MTB_ArticlesController(MyTecBitsDBContext ctx)
        {
            this._ctx = ctx;
        }
        //
        // GET: /MTB_Articles/

        public ActionResult Index()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            Console.Out.WriteLine("Let's assume you're going to work, and using the bus to get there:");
            Console.Out.WriteLine("------------------------------------------------------------------");
            logger.Trace("Trace: The chatter of people on the street");
            logger.Debug("Debug: Where are you going and why?");
            logger.Info("Info: What bus station you're at.");
            logger.Warn("Warn: You're playing on the phone and not looking up for your bus");
            logger.Error("Error: You get on the wrong bus.");
            logger.Fatal("Fatal: You are run over by the bus.");
            Seed();
            var model = _ctx.Articles;
            return View(model);
        }

        //
        // GET: /MTB_Articles/Details/5

        public async Task<ActionResult> Details(int id)
        {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var model = await _ctx.Articles.FindAsync(id);
                if (model == null)
                {
                    return HttpNotFound();
                }

            return View(model);
        }

        //
        // GET: /MTB_Articles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MTB_Articles/Create

        [HttpPost]
        public ActionResult Create(MTB_Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Articles.Add(article);
                    _ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        //
        // GET: /MTB_Articles/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var model = await _ctx.Articles.FindAsync(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        //
        // POST: /MTB_Articles/Edit/5

        [HttpPost]
        public ActionResult Edit(MTB_Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Entry(article).State = EntityState.Modified;
                    _ctx.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MTB_Articles/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = await _ctx.Articles.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        //
        // POST: /MTB_Articles/Delete/5

        [HttpPost]
        public ActionResult Delete(MTB_Article article)
        {
            try
            {
                _ctx.Entry(article).State = EntityState.Deleted;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View();
            }
        }
        public ActionResult Search(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return new HttpNotFoundResult();
            }
            
            var search = _ctx.Articles.Where(x => x.Title.Contains(searchText) || x.Content.Contains(searchText));
            Mapper.CreateMap<MTB_Article, ArticleSearchResult>().ForMember(x => x.PageRank, opt => opt.MapFrom(src => src.Id)).ForMember(x => x.Link, opt => opt.MapFrom(src => Smart.Format("{Id}", src)));
            var model = new List<ArticleSearchResult>();

            foreach (var s in search)
            {
                model.Add(Mapper.Map<MTB_Article, ArticleSearchResult>(s));
            }
            return View(model);
        }

        #region HELPERS
        private void Seed()
        {
            //if (_ctx.Articles.Count() <= 1)
            //{
            //    var art = new MTB_Article() { Title = "The Sopranos", Excerpt = "Modern day morality tale about New Jersey mob boss", Content = "Modern day morality tale about New Jersey mob boss Tony Soprano, as he deals with personal and professional issues in his home and business life." };
            //    _ctx.Articles.Add(art);
            //    art = new MTB_Article() { Title = "Game of Thrones", Excerpt = "Fight for control of the mythical land of Westeros", Content = "Seven noble families fight for control of the mythical land of Westeros" };
            //    _ctx.Articles.Add(art);
            //    art = new MTB_Article() { Title = "Breaking Bad", Excerpt = "A high school chemistry teacher turns to a life of crime", Content = "A high school chemistry teacher turns to a life of crime in order to provide for his family's future" };
            //    _ctx.Articles.Add(art);
            //    _ctx.SaveChanges();
            //}
        }
        #endregion
    }
}
