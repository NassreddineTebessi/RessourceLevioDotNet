using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DATA;
using DOMAIN;
using Microsoft.AspNet.SignalR;
using RestSharp;
using WEB.Hubs;

namespace WEB.Controllers
{
    public class MandateController : Controller
    {
        private String url = "http://localhost:18080/map-web/map/";
        private Context c = new Context();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        // POST: Mandate
        public ActionResult Add(FormCollection collection)
        {
            try

            {
                var client = new RestClient(url);

                var request = new RestRequest("mandate/assign", Method.POST);
                request.AddParameter("projtid", collection["project_id"], ParameterType.QueryString);
                request.AddParameter("resid", collection["ressource_id"], ParameterType.QueryString);
                request.AddParameter("sdate", collection["StartDate"], ParameterType.QueryString);
                request.AddParameter("edate", collection["EndDate"], ParameterType.QueryString);
                request.AddParameter("cost", collection["Montant"], ParameterType.QueryString);
                request.AddHeader("Accept", "application/json");
                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                Console.WriteLine(request.ToString());
                Console.WriteLine(response.Content);
                return RedirectToAction("Index");
            }

            catch

            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("mandate").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
            }
            else
            {
                ViewBag.result = "Error";
            }

            return View();
        }


        [HttpPost]
        public ActionResult Delete()
        {
            try

            {
                var routeValues = Url.RequestContext.RouteData.Values;
                var paramName = "mandateid";
                var id = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

                var client = new RestClient(url);

                var request = new RestRequest("mandate/delete", Method.POST);
                request.AddParameter("mandateid", id, ParameterType.QueryString);

                request.AddHeader("Accept", "application/json");

                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content;


                return RedirectToAction("Index");
            }

            catch

            {
                return View();
            }
        }

        public static void SendMessage(String msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.addNewMessageToPage();
        }

        [HttpGet]
        public ActionResult EditMandate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            mandate m = c.mandates.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            return View(m);
        }

        [HttpPost]
        public ActionResult EditMandate(FormCollection collection)
        {
            try

            {
                var client = new RestClient(url);

                var request = new RestRequest("mandate/edit", Method.PUT);
                /* request.AddParameter("id", collection["project_id"], ParameterType.QueryString);
                 request.AddParameter("projtid", collection["project_id"], ParameterType.QueryString);
                 request.AddParameter("resid", collection["ressource_id"], ParameterType.QueryString);
                 request.AddParameter("sdate", collection["StartDate"], ParameterType.QueryString);
                 request.AddParameter("edate", collection["EndDate"], ParameterType.QueryString);
                 request.AddParameter("cost", collection["Montant"], ParameterType.QueryString);*/

                request.AddHeader("Content-type", "application/json");
                request.AddJsonBody(
                    new
                    {
                        id = collection["id"],
                        montant = collection["Montant"],
                        startDate = collection["StartDate"],
                        endDate = collection["EndDate"]
                    }); // 
                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content;

                return RedirectToAction("Index");
            }

            catch

            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult History()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("mandate/history").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
            }
            else
            {
                ViewBag.result = "Error";
            }

            return View();
        }
        [HttpGet]
        public ActionResult Archived()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("mandate/archive").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
            }
            else
            {
                ViewBag.result = "Error";
            }

            return View();
        }

    }
}