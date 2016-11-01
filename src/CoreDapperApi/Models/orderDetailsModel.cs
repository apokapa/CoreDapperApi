using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDapperApi.Models
{
    public class orderDetailsModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
