using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace WEB.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult ListClients()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/client/clients").Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ClientModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }

        public ActionResult ProjectsByClient(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/project/projectbyclient/"+id).Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ClientModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }

        [HttpGet]
        public ActionResult createClient()
        {
            return View("createClient");

        }

        [HttpPost]
        public ActionResult createClient(ClientModel c)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            client.PostAsJsonAsync<ClientModel>("map-web/map/client", c)
                .ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("ListClients");
        }

        public ActionResult deleteClient(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PutAsJsonAsync<ClientModel>("map-web/map/client/delete/"+id, null)
                .ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("ListClients");
        }

        public ActionResult DetailClient(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/client/"+id).Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<ClientModel>().Result;
                Console.WriteLine(ViewBag.result);

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }

        public ActionResult EditClient(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/client/" + id).Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<ClientModel>().Result;
                Console.WriteLine(ViewBag.result);

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientModel c)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:18080");

            //client.PutAsJsonAsync<ClientModel>("map-web/map/client/update", c)
            //    .ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            String id = HttpContext.Request.Params.Get("idClient");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client
                .PutAsJsonAsync("map-web/map/client/update/"+ id, c).Result;
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("succes");
            }
            else
            {
                ViewBag.result = "error";
            }
            return RedirectToAction("ListClients");
        }
        
        
    }
}