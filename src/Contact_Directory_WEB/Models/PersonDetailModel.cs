using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Directory_WEB.Models
{
    public class PersonDetailModel
    {
        public int personId { get; set; }
        public List<PersonDetail> personDetailList { get; set; }
    }
}
