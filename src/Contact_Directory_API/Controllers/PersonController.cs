using Contact_Directory_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Linq;

namespace Contact_Directory_API.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [HttpGet]
        public String Get()
        {
            return new JavaScriptSerializer().Serialize(db.Persons.ToList());
        }

        [HttpGet("{id}")]
        public String Get(int id)
        {
            return new JavaScriptSerializer().Serialize(db.Persons.Find(id));
        }

        [HttpPost]
        public void Post(Person per)
        {
            try
            {
                if (per.personId == 0)
                {
                    if (string.IsNullOrEmpty(per.name))
                    {
                        throw new Exception("Name is not null or empty!!!");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(per.tel1+per.tel2+per.email1+per.email2))
                        {
                            throw new Exception("En az bir tane iletişim bilgisi giriniz!!!");
                        }
                        else
                        {
                            db.Persons.Add(per);
                        }
                    }

                }
                else
                {
                    if (per.personId > 0)
                    {
                        db.Entry(per).State = EntityState.Modified;
                    }
                    else
                    {
                        throw new Exception("Data not found!!!");
                    }

                }
                db.SaveChanges();
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
                db.Persons.Remove(db.Persons.Find(id));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
