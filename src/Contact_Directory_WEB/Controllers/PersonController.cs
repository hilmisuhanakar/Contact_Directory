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
                ViewBag.Data = GetApiListData(); // Tum Listeyi Getirme Methodu Kullaniliyor.

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
                var apiUrl = "http://localhost:6300/api/person"; // Contact_Directory_API servisindeki Get Methodu Icin URL verildi.

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
                var apiUrl = "http://localhost:6300/api/person" + "/" + id; // Contact_Directory_API Servisindeki Tek Datanin Verisi Icin Get Methodu URL verildi.

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

        public PersonDetailModel GetApiDetailData(int id)
        {
            PersonDetailModel pModel = new PersonDetailModel();
            pModel.personId = id;
            try
            {
                var apiUrl = "http://localhost:63941/api/detail" + "/" + id; // Contact_Directory_API2 servisindeki Kisinin Detay Bilgileri Icin URL verildi.

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<PersonDetail> jsonData = ser.Deserialize<List<PersonDetail>>(json);
                pModel.personDetailList = jsonData;
                //END

                return pModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Detail2(int id)
        {
            try
            {
                return View(GetApiDetailData(id));
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
            var result = client.PostAsync("http://localhost:6300/api/person", new Person // Contact_Directory_API Kisi Eklemek veya Guncellemek Icin Post URL Verildi.
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

        [HttpGet]
        public ActionResult Add2(int detailId, int personId)
        {
            PersonDetail jsonData = new PersonDetail();
            jsonData.personId = personId;
            
            return View(jsonData);

        }
        public ActionResult Post2(PersonDetail persondetail)
        {
            HttpClient client = new HttpClient();
            var result = client.PostAsync("http://localhost:63941/api/detail", new PersonDetail // Contact_Directory_API2 Kisi Detayı Eklemek Icin Post Url Verildi.
            {
                personDetailId = persondetail.personDetailId,
                personId = persondetail.personId,
                tel = persondetail.tel,
                email = persondetail.email,
                location = persondetail.location
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
                HttpResponseMessage resposne = client.DeleteAsync("http://localhost:6300/api/person" + "/" + id).Result; // Contact_Directory_API Kisi Silmek Icin Delete URL verildi.

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Delete2(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://localhost:63941/api/detail" + "/" + id) //Contact_Directory_API2 Kisi Detayi Silmek Icin Url Verildi.
                };
                HttpResponseMessage resposne = client.DeleteAsync("http://localhost:63941/api/detail" + "/" + id).Result;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
