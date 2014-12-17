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

    public class BasketballPlaybookController : Controller
    {

        public BasketballPlaybookController()
        {
        }
        //
        // GET: /MTB_Articles/

        public ActionResult Index()
        {
            return View();
        }
    }
}
