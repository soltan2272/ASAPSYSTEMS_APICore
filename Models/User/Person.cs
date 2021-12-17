using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Person:BaseModel
    {
       
        public string First_Name { set; get; }
        public string Last_Name { set; get; }
        public string Email { set; get; }
        public int Phone { set; get; }

        public ICollection<Address> Addresses { get; set; }

    }
}
