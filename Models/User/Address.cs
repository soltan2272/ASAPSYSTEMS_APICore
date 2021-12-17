using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Address: BaseModel
    {
        public string Country { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Postal_Code { set; get; }

        public int CurrentPersonId { get; set; }
        public Person person { get; set; }
    }
}
