using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WEB.Models;

namespace WEB.Controllers
{

    public class RequestController : Controller
    {
        MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection(
            "server=localhost;user id=root;password=V4Vendetta;database=leviomap");

        public ActionResult Index() 
        {
            IEnumerable<RequestModel> requestList;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/map-web/map/User/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("getAllRequests").Result;
            try
            {
                    requestList = response.Content.ReadAsAsync<IEnumerable<RequestModel>>().Result;

            }
            catch (AggregateException e)
            {

                Console.WriteLine(e);
                throw;
            }
         
            return View(requestList);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/map-web/map/client/");
            HttpResponseMessage response = client.GetAsync("DeleteRequest?id=" + id).Result;
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult DeleteTreatedRequests()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/map-web/map/User/");
            HttpResponseMessage response = client.GetAsync("deleteTreatedRequets").Result;
            return RedirectToAction("Index");

        }

          [HttpPost]
        public ActionResult TreatRequest(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/map-web/map/User/");
            HttpResponseMessage response = client.GetAsync("treatClientRequest?requestId="+id).Result;
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult AddClientRequest(String resource, String project, DateTime projectDate)
        {
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText =
                "INSERT into request (context, deliveryDate, resourceType, status) VALUES (@project, @delivery, @resource, @status)";
            cmd.Parameters.AddWithValue("@project", project);
            cmd.Parameters.AddWithValue("@delivery", projectDate);
            cmd.Parameters.AddWithValue("@resource", resource);
            cmd.Parameters.AddWithValue("@status", 0);

            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);


            }
            cmd.ExecuteNonQuery();            
            cmd.CommandText =
                "INSERT into client_request  VALUES (2, (select id from request order by id desc limit 1))";
            cmd.ExecuteNonQuery();
            return RedirectToAction("AddClientRequest");
        }


        [HttpGet]
        public ActionResult AddClientRequest()
        {
            List<ProjectModel> listeProject = new List<ProjectModel>();
            MySqlCommand cmd1 = dbConn.CreateCommand();
            cmd1.CommandText = "select id,name from project";
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }

            MySqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {
                ProjectModel projectmodel = new ProjectModel();
                projectmodel.id = Convert.ToInt32(reader.GetValue(0));
                projectmodel.name = Convert.ToString(reader.GetValue(1));
                listeProject.Add(projectmodel);
            }
            reader.Close();
            return View(listeProject);
        }

        [HttpGet]
        public ActionResult viewClientRequests()
        {
            List<RequestModel> listeRequest = new List<RequestModel>();
            MySqlCommand cmd1 = dbConn.CreateCommand();
            cmd1.CommandText = "select * from request where id in (select requests_id from client_request where clients_id = 2)";
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }

            MySqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {
                RequestModel requestmodel = new RequestModel();
                requestmodel.id = Convert.ToInt32(reader.GetValue(0));
                requestmodel.context = Convert.ToString(reader.GetValue(1));
                requestmodel.deliveryDate = Convert.ToDateTime(reader.GetValue(2));
                requestmodel.resourceType = Convert.ToString(reader.GetValue(3));
                requestmodel.status = (Convert.ToInt32(reader.GetValue(4)) == 0 ? false : true);
                listeRequest.Add(requestmodel);
            }
            reader.Close();
            return View(listeRequest);
        }



        [HttpGet]
        public ActionResult deleteClientRequest(int id)
        {
            MySqlCommand cmd1 = dbConn.CreateCommand();
            cmd1.CommandText = "delete from client_request where clients_id = 2 and requests_id = @id ";
            cmd1.Parameters.AddWithValue("@id", id);
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }

            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "delete from request where id = @id";
            cmd1.ExecuteNonQuery();
            return RedirectToAction("viewClientRequests");
        }

    }

}