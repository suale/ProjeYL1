using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLabSite.Models;

namespace YazLabSite.Controllers
{
    public class Asama4Controller : Controller
    {
        [Route("Asama4/Index")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Asama4/Index")]
        [HttpPost]
        public ActionResult Index(string gelenUrl, string gelenUrl1, string gelenUrl2, string gelenUrl3, string gelenUrl4, string gelenUrl5, string gelenUrl6, string gelenUrl7, string gelenUrl8, string gelenUrl9, string gelenUrl10, string gelenUrl11, string gelenUrl12, string gelenUrl13, string gelenUrl14, string gelenUrl15)
        {
            string asilUrl = gelenUrl;

            List<string> urlLer = new List<string>();
            urlLer.Add(gelenUrl1);
            urlLer.Add(gelenUrl2);
            urlLer.Add(gelenUrl3);
            urlLer.Add(gelenUrl4);
            urlLer.Add(gelenUrl5);
            urlLer.Add(gelenUrl6);
            urlLer.Add(gelenUrl7);
            urlLer.Add(gelenUrl8);
            urlLer.Add(gelenUrl9);
            urlLer.Add(gelenUrl10);
            urlLer.Add(gelenUrl11);
            urlLer.Add(gelenUrl12);
            urlLer.Add(gelenUrl13);
            urlLer.Add(gelenUrl14);
            urlLer.Add(gelenUrl15);





            return View();
        }

    }
}