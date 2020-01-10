using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProjectController : Controller 
    {
        public ActionResult ListProjects()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/project/projects").Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ProjectModel>>().Result;

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }

        
        [HttpGet]
        public ActionResult createProject()
        {
            return View("createProject");

        }

        [HttpPost]
        public ActionResult createProject(ProjectModel p, HttpPostedFileBase ImageFile)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");

            if (ImageFile != null)
            {
                string filename = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(Server.MapPath("/Content/ProjectImages"), filename);
                ImageFile.SaveAs(path);
                p.photo = filename;
            }

            client.PostAsJsonAsync<ProjectModel>("map-web/map/project/add/"+p.client_id, p)
                .ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("ListProjects");
        }

       
        public ActionResult deleteProject(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PutAsJsonAsync<ProjectModel>("map-web/map/project/delete/"+id, null)
                .ContinueWith((e => e.Result.EnsureSuccessStatusCode()));
            return RedirectToAction("ListProjects");
        }

        public ActionResult DetailProject(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("map-web/map/project/" + id).Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<ProjectModel>().Result;
                Console.WriteLine(ViewBag.result);

            }

            else
            {
                ViewBag.result = "error";

            }

            return View();
        }



    }
}