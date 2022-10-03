using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ManageOrders()
        {
            List<OrderDto> models = await orderService.GetAllAsync();
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            OrderDto order = await orderService.GetById(id);

            return View(order);
        }
    }
}