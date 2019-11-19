using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using HalalBakersShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalalBakersShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemsRepository _pieRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IItemsRepository pieRepository,UserManager<IdentityUser> userManager)
        {
            _pieRepository = pieRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ItemsOfTheWeek = _pieRepository.ItemsOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}
