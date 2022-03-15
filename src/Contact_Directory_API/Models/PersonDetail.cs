using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Directory_API.Models
{
    public class PersonDetail
    {
        [Key]
        public int personDetailId { get; set; }
        public int personId { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string location { get; set; }
    }
}
