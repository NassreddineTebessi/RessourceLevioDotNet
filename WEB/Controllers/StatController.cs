using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class StatController : Controller
    {
        // GET: Stat
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage skills = Client.GetAsync("map-web/map/dashboard/skills").Result;
            if(skills.IsSuccessStatusCode)
            {
                ViewBag.skills = skills.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.skills = "error";
            }
            HttpResponseMessage mostProfitProject = Client.GetAsync("map-web/map/dashboard/mostprofitproject").Result;
            if (mostProfitProject.IsSuccessStatusCode)
            {
                ViewBag.mostProfitProject = mostProfitProject.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.mostProfitProject = "error";
            }
            HttpResponseMessage mostprofitclient = Client.GetAsync("map-web/map/dashboard/mostprofitclient").Result;
            if (mostprofitclient.IsSuccessStatusCode)
            {
                ViewBag.mostprofitclient = mostprofitclient.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.mostprofitclient = "error";
            }
            HttpResponseMessage numresmandates = Client.GetAsync("map-web/map/dashboard/numresmandates").Result;
            if (numresmandates.IsSuccessStatusCode)
            {
                ViewBag.numresmandates = numresmandates.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.numresmandates = "error";
            }
            HttpResponseMessage getnumempintermand = Client.GetAsync("map-web/map/dashboard/getnumempintermand").Result;
            if (getnumempintermand.IsSuccessStatusCode)
            {
                ViewBag.getnumempintermand = getnumempintermand.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.getnumempintermand = "error";
            }
            HttpResponseMessage getnumempadmin = Client.GetAsync("map-web/map/dashboard/getnumempadmin").Result;
            if (getnumempadmin.IsSuccessStatusCode)
            {
                ViewBag.getnumempadmin = getnumempadmin.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.getnumempadmin = "error";
            }
            HttpResponseMessage numemployees = Client.GetAsync("map-web/map/dashboard/numemployees").Result;
            if (numemployees.IsSuccessStatusCode)
            {
                ViewBag.numemployees = numemployees.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.numemployees = "error";
            }
            HttpResponseMessage numfreelancers = Client.GetAsync("map-web/map/dashboard/numfreelancers").Result;
            if (numfreelancers.IsSuccessStatusCode)
            {
                ViewBag.numfreelancers = numfreelancers.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.numfreelancers = "error";
            }

            HttpResponseMessage reclamations = Client.GetAsync("map-web/map/dashboard/reclamations").Result;
            if (reclamations.IsSuccessStatusCode)
            {
                ViewBag.reclamations = reclamations.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.reclamations = "error";
            }
            HttpResponseMessage satisfactions = Client.GetAsync("map-web/map/dashboard/satisfactions").Result;
            if (satisfactions.IsSuccessStatusCode)
            {
                ViewBag.satisfactions = satisfactions.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.satisfactions = "error";
            }
            HttpResponseMessage satisfactionrate = Client.GetAsync("map-web/map/dashboard/satisfactionrate").Result;
            if (satisfactionrate.IsSuccessStatusCode)
            {
                ViewBag.satisfactionrate = satisfactionrate.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.satisfactionrate = "error";
            }
            HttpResponseMessage resources = Client.GetAsync("map-web/map/ressource").Result;
            if (resources.IsSuccessStatusCode)
            {


                ViewBag.resources = resources.Content.ReadAsStringAsync().Result;

            }

            else
            {
                ViewBag.resources = "error";

            }
            HttpResponseMessage projects = Client.GetAsync("map-web/map/project/projects").Result;
            if (projects.IsSuccessStatusCode)
            {


                ViewBag.projects = projects.Content.ReadAsStringAsync().Result;

            }

            else
            {
                ViewBag.projects = "error";

            }

            return View();
        }
        [HttpGet]
        public string getReport(int resourceId)
        {
            string result;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/map/dashboard/report/"+resourceId).Result;
            if (response.IsSuccessStatusCode)
            {
                result = "OK";
            }
            else
            {
                result = "error";
            }
            return result;
        }
        [HttpGet]
        public string getResourceById(int resourceId)
        {
            string result;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/map/ressource?id=" + resourceId).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = "error";
            }
            return result;
        }
        [HttpGet]
        public string getResourceEff(int resourceId)
        {
            string result;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/map/dashboard/reseff/" + resourceId).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = "error";
            }
            return result;
        }
        [HttpGet]
        public string getProjectEff(int projectId)
        {
            string result;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("map-web/map/dashboard/projecteff/" + projectId).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = "error";
            }
            return result;
        }
    }
}