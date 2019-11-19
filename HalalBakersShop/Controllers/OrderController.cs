using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using HalalBakersShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                ModelState.AddModelError("", "Your cart is empty, add some Bakers Items first");
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
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious Items Soon!";
            return View();
        }


        public IActionResult PendingOrders()
        {
            List<OrderDetailsForUser> details = new List<OrderDetailsForUser>();
            var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderID = _appDbContext.Orders.Where(x => x.UserID == userId && x.InProcess == true).ToList() ;
            if (orderID!=null && orderID.Count != 0)
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
            if (orderID != null && orderID.Count != 0)
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

        public IActionResult AllPendingOrders()
        {
            List<AdminPendingOrders> details = new List<AdminPendingOrders>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderID = _appDbContext.Orders.Where(x => x.UserID == userId && x.InProcess == true).ToList();
            if (orderID != null && orderID.Count!=0)
            {
                foreach (var order in orderID)
                {
                    List<OrderDetail> orderDetails = _appDbContext.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var detail in orderDetails)
                    {
                        AdminPendingOrders orderDetail = new AdminPendingOrders();
                        orderDetail.OrderID = order.OrderId;
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


        public IActionResult Edit(int id)
        {
            Order order = _appDbContext.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            order.IsDelivered = true;
            order.InProcess = false;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AllDeliveredOrders()
        {
            List<OrderDetailsForUser> details = new List<OrderDetailsForUser>();
            List<Order> orders = _appDbContext.Orders.ToList();
            if (orders.Count!=0)
            {
                foreach (var order in orders)
                {
                    List<OrderDetail> orderDetails = _appDbContext.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var orderDetail in orderDetails)
                    {
                        Items item = _appDbContext.Items.Where(x => x.ItemsId == orderDetail.ItemsId).FirstOrDefault();
                        OrderDetailsForUser orderDetailsForUser = new OrderDetailsForUser();
                        orderDetailsForUser.Name = $"{order.FirstName} {order.LastName}";
                        orderDetailsForUser.DateTime = order.OrderPlaced;
                        orderDetailsForUser.ItemName = item.Name;
                        orderDetailsForUser.Quantity = orderDetail.Amount;
                        orderDetailsForUser.IsDelivered = true;
                        orderDetailsForUser.InProccess = false;
                        details.Add(orderDetailsForUser);
                    }
                }
                return View(details);
            }
            ViewBag.cat = true;
            return View();
        }
        
    }
}
