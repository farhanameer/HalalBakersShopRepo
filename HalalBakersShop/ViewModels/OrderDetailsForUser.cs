using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalalBakersShop.ViewModels
{
    public class OrderDetailsForUser
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }


        public bool IsDelivered { get; set; }

        public bool InProccess { get; set; }
    }
}
