using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using HalalBakersShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalalBakersShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _appDbContext;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart,AppDbContext appDbContext)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;
        }

        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                order.UserID = userId;
                order.IsDelivered = false;
                order.InProcess = true;
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }


        public IActionResult PendingOrders()
        {
            List<OrderDetailsForUser> details = new List<OrderDetailsForUser>();
            var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderID = _appDbContext.Orders.Where(x => x.UserID == userId && x.InProcess == true).ToList() ;
            if (orderID!=null)
            {
                foreach (var order in orderID)
                {
                    List<OrderDetail> orderDetails = _appDbContext.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var detail in orderDetails)
                    {
                        OrderDetailsForUser orderDetail = new OrderDetailsForUser();
                        orderDetail.Name = $"{order.FirstName} {order.LastName}";
                        orderDetail.DateTime = order.OrderPlaced;
                        var itemName = _appDbContext.Items.Where(x => x.ItemsId == detail.ItemsId).FirstOrDefault();
                        orderDetail.ItemName = itemName.Name;
                        orderDetail.Quantity = detail.Amount;
                        orderDetail.IsDelivered = false;
                        orderDetail.InProccess = true;
                        details.Add(orderDetail);
                    }
                }
                return View(details);
            }
            ViewBag.cat = true;
            return View();
        }


        public IActionResult DeliveredOrders()
        {
            List<OrderDetailsForUser> details = new List<OrderDetailsForUser>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderID = _appDbContext.Orders.Where(x => x.UserID == userId && x.IsDelivered == true).ToList();
            if (orderID != null)
            {
                foreach (var order in orderID)
                {
                    List<OrderDetail> orderDetails = _appDbContext.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var detail in orderDetails)
                    {
                        OrderDetailsForUser orderDetail = new OrderDetailsForUser();
                        orderDetail.Name = $"{order.FirstName} {order.LastName}";
                        orderDetail.DateTime = order.OrderPlaced;
                        var itemName = _appDbContext.Items.Where(x => x.ItemsId == detail.ItemsId).FirstOrDefault();
                        orderDetail.ItemName = itemName.Name;
                        orderDetail.Quantity = detail.Amount;
                        orderDetail.IsDelivered = true;
                        orderDetail.InProccess = false;
                        details.Add(orderDetail);
                    }
                }
                return View(details);
            }
            ViewBag.cat = true;
            return View();
        }
    }
}
