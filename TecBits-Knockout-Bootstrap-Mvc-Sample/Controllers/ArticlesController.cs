using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TecBits_Knockout_Bootstrap_Mvc_Sample.Models;

namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Controllers.v1
{
    public class ArticlesController : ApiController
    {
        private MyTecBitsDBContext _ctx;

        public ArticlesController(MyTecBitsDBContext ctx)
        {
            this._ctx = ctx;
        }
        // GET api/defaultapi
        public IEnumerable<MTB_Article> Get()
        {
            return _ctx.Articles.Include("Author");
        }

        // GET api/defaultapi/5
        public MTB_Article Get(int id)
        {
            var article = _ctx.Articles.Include("Author").Where(x => x.Id == id).First();
           return article;
        }

        // POST api/defaultapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/defaultapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/defaultapi/5
        public void Delete(int id)
        {
        }
    }
}
