using Contact_Directory_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Contact_Directory_WEB.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.Data = GetApiListData();

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetApiListData()
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

        public Person GetApiData(int id)
        {
            try
            {
                var apiUrl = "http://localhost:6300/api/person" + "/" + id;

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Person jsonData = ser.Deserialize<Person>(json);
                //END
                ViewBag.id = id;
                ViewBag.Title = jsonData.name + " " + jsonData.surname;
                return jsonData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Detail(int id)
        {
            try
            {
                return View(GetApiData(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            HttpClient client = new HttpClient();
            var result = client.PostAsync("http://localhost:6300/api/person", new Person
            {
                personId = person.personId,
                name = person.name,
                surname = person.surname,
                tel1 = person.tel1,
                tel2 = person.tel2,
                email1 = person.email1,
                email2 = person.email2,
                location = person.location
            }, new JsonMediaTypeFormatter()).Result;
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://localhost:6300/api/person" + "/" + id)
                };
                HttpResponseMessage resposne = client.DeleteAsync("http://localhost:6300/api/person" + "/" + id).Result;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
