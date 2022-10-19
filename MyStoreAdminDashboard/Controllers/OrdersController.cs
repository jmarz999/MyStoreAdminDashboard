using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Helpers;
using MyStoreAdminDashboard.Services;

namespace MyStoreAdminDashboard.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ManageOrders()
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            List<OrderDto> models = await orderService.GetAllAsync(Encoding.ASCII.GetString(token));
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            OrderDto order = await orderService.GetById(id, Encoding.ASCII.GetString(token));

            return View(order);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int orderId, string status)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            OrderDto order = await orderService.GetById(orderId, Encoding.ASCII.GetString(token));
            order.Status = status;

            await orderService.Update(order, Encoding.ASCII.GetString(token));

            return RedirectToAction(nameof(ManageOrders));
        }
    }
}