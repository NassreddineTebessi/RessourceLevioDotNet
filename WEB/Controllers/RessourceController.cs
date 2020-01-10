using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http.Headers;
using WEB.Models;

namespace WEB.Controllers
{
    public class RessourceController : Controller
    {
        // GET: Ressource
        public ActionResult ListRessources()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/ressource").Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RessourceModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }


        [HttpGet]
        public ActionResult createRessource()
        {
            return View("createRessource");

        }

        [HttpPost]
        public ActionResult createRessource(RessourceModel res)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PostAsJsonAsync<RessourceModel>("map-web/map/ressource", res).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("ListRessources");
        }

        [HttpPut]
        public ActionResult deleteRessource(RessourceModel res)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PutAsJsonAsync<RessourceModel>("map-web/map/ressource/archiver", res).ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("Index");
        }



    }
}