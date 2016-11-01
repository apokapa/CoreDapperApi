using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDapperApi.Models
{
    public class customersModel
    {
        public customersModel()
        {
            Orders = new List<ordersModel>();
        }


        public int Id { get; set; }
        public string Vat { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<ordersModel> Orders { get; set; }


    }
}
