using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Directory_WEB.Models
{
    public class PersonDetail
    {
        public int personDetailId { get; set; }
        public int personId { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string location { get; set; }
    }
}
