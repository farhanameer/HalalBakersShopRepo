using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalalBakersShop.Models;

namespace HalalBakersShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Items> ItemsOfTheWeek { get; set; }
    }
}
