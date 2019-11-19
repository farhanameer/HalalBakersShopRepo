using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using HalalBakersShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalalBakersShop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ItemsController : Controller
    {
        private readonly IItemsRepository _ItemsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ItemsController(IItemsRepository ItemsRepository, ICategoryRepository categoryRepository,UserManager<IdentityUser> userManager)
        {
            _ItemsRepository = ItemsRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }





        public IActionResult Index()
        {
            IEnumerable<Items> Items = _ItemsRepository.AllItems;
            return View(Items);
        }

        // GET: /<controller>/
        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";

        //    //return View(_ItemsRepository.AllItemss);
        //    ItemssListViewModel ItemssListViewModel = new ItemssListViewModel();
        //    ItemssListViewModel.Itemss = _ItemsRepository.AllItemss;

        //    ItemssListViewModel.CurrentCategory = "Cheese cakes";
        //    return View(ItemssListViewModel);
        //}
        [AllowAnonymous]
        public ViewResult List(string category)
        {
            IEnumerable<Items> items;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                items = _ItemsRepository.AllItems.OrderBy(p => p.ItemsId);
                currentCategory = "All Items";
            }
            else
            {
                items = _ItemsRepository.AllItems.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ItemsId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ItemsListViewModel
            {
                Items = items,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var Items = _ItemsRepository.GetItemsById(id);
            if (Items == null)
                return NotFound();

            return View(Items);
        }

        [HttpGet]
        public IActionResult AddItems()
        {
            ViewBag.cat = _categoryRepository.AllCategories;
            return View();
        }
        [HttpPost]
        public IActionResult AddItems(Items items)
        {
            _ItemsRepository.AddItems(items);
            return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Items items = _ItemsRepository.GetItemsById(id);
            ViewBag.cat = _categoryRepository.AllCategories;
            return View(items);
        }
        [HttpPost]
        public IActionResult Edit(Items items)
        {
            bool result = _ItemsRepository.updateItems(items);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Items items = _ItemsRepository.GetItemsById(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFull = await _userManager.FindByIdAsync(userId);
            var userFullRole = await _userManager.GetRolesAsync(userFull);
            var ad = "";
            if (userFullRole[0]=="Admin")
            {
                ad = "admin";
            }
            var userEmail = User.FindFirstValue(ClaimTypes.Name);
            var userRol= User.FindFirstValue(ClaimTypes.Role);
            var user = this.User;
            
            
            var rol=User.IsInRole("Admin");

            return View(items);
        }

        [HttpPost]
        public IActionResult Delete(Items items)
        {
            if (_ItemsRepository.deleteItem(items))
            {
                return RedirectToAction("Index");
            }
            return View(items);
        }

    }
}
