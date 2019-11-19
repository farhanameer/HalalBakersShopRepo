using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalalBakersShop.Models;

namespace HalalBakersShop.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Items> Items { get; set; }
        public string CurrentCategory { get; set; }
    }
}
