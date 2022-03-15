using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Directory_API.Models
{
    public class Person
    {
        [Key]
        public int personId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string tel1 { get; set; }
        public string tel2  { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string location { get; set; }

        public Person()
        {
            personId = 0;
            name = "";
            surname = "";
            tel1 = "";
            tel2 = "";
            email1 = "";
            email2 = "";
            location = "";
        }
    }
}
