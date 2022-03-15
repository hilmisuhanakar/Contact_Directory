using Contact_Directory_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Contact_Directory_API2.Controllers
{
    [Route("api/detail")]
    [ApiController]
    public class PersonDetailController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [HttpGet("{id}")]
        public String Get(int id)
        {
            try
            {
                var apiUrl = "http://localhost:6300/api/person" + "/" + id; // Contact_Directory_API Web Servisinden Kisi Bilgisi Aliniyor.

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Person jsonData = ser.Deserialize<Person>(json);
                if (jsonData.personId <= 0)
                {
                    throw new Exception("Data not found");
                }

                //END

                return new JavaScriptSerializer().Serialize(db.PersonDetails.Where(x => x.personId == id).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public void Post(PersonDetail perdetail) // Kisiklerin Detay Bilgileri Ekleniyor.
        {
            try
            {
                db.PersonDetails.Add(perdetail);
                db.SaveChanges();
                if (perdetail.personDetailId>0)
                {
                    db.Entry(perdetail).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String GetData(int pId,int dId) // Kisilerin Detay Bilgisi Aliniyor.
        {
            try
            {
                var apiUrl = "http://localhost:6300/api/person" + "/" + pId;

                //Connect API
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);
                //END

                //JSON Parse START
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Person jsonData = ser.Deserialize<Person>(json);
                if (jsonData.personId <= 0)
                {
                    throw new Exception("Data not found");
                }

                //END
                var a = new JavaScriptSerializer().Serialize(db.PersonDetails.Where(x => x.personId == pId && x.personDetailId == dId)); // personID ve personDetailId Degerleri Veri Tabanında Var Mi Diye Kontrol Ediliyor.
                return a;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    throw new Exception("Id is not null or empty!!!");
                }
                db.PersonDetails.Remove(db.PersonDetails.Find(id));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

