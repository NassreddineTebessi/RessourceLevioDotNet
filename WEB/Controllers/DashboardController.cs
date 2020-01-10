using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http.Headers;
using WEB.Models;

namespace WEB.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }


    }

}