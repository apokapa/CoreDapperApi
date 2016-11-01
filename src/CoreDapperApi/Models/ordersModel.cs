using CoreDapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDapperApi.Models
{
    public class ordersModel
    {

        public ordersModel()
        {
            orderDetails = new List<orderDetailsModel>();
        }

        public int id { get; set; }
        public int customerId { get; set; }
        public string number { get; set; }
        public string descr { get; set; }
        public DateTime date { get; set; }

        public List<orderDetailsModel> orderDetails { get; set; }

    }
}
