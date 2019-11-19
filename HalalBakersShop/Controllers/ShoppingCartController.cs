using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using HalalBakersShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalalBakersShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IItemsRepository _ItemsRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IItemsRepository itemsRepository, ShoppingCart shoppingCart)
        {
            _ItemsRepository = itemsRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            var selectedItems = _ItemsRepository.AllItems.FirstOrDefault(p => p.ItemsId == itemId);

            if (selectedItems != null)
            {
                _shoppingCart.AddToCart(selectedItems, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var selectedItems = _ItemsRepository.AllItems.FirstOrDefault(p => p.ItemsId == itemId);

            if (selectedItems != null)
            {
                _shoppingCart.RemoveFromCart(selectedItems);
            }
            return RedirectToAction("Index");
        }
    }
}
