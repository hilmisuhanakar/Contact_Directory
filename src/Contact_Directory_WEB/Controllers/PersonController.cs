using Contact_Directory_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contact_Directory_WEB.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.Data = GetApiData();

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetApiData()
        {
            try
            {
                var apiUrl = "http://localhost:6300/api/person";

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Person> jsonList = ser.Deserialize<List<Person>>(json);
                //END

                return jsonList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetApiData(int id)
        {
            try
            {
                var apiUrl = "http://localhost:6300/api/person/" + id;

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Person> jsonList = ser.Deserialize<List<Person>>(json);
                //END
                ViewBag.id = id;
                return jsonList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                ViewBag.Data = GetApiData(id);

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete]

        public JsonResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:6300/api/person/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var rslt = response.Content.ReadAsStringAsync().Result;
                JsonConvert.DeserializeObject<Person>(rslt);
            }
            return Json("False");
        }

    }
}
