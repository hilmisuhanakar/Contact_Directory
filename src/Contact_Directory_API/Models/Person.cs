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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string tel1 { get; set; }
        public string tel2  { get; set; }
        public string email1 { get; set; }
        public string emaikl2 { get; set; }
        public string location { get; set; }

        public Person()
        {
            personId = 0;
            Name = "";
            Surname = "";
            tel1 = "";
            tel2 = "";
            email1 = "";
            emaikl2 = "";
            location = "";
        }
    }
}
