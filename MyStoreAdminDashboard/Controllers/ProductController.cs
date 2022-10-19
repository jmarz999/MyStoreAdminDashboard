using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreAdminDashboard.Helpers;
using MyStoreAdminDashboard.Services;

namespace MyStoreAdminDashboard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Create()
        {
            CreateProductDto model = new CreateProductDto();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.TryGetValue("Token", out byte[] token);

                var response = await productService.Create(model, Encoding.ASCII.GetString(token));

                if (response)
                {
                    return RedirectToAction(nameof(ManageProducts));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Product already exists");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageProducts()
        {
            List<ProductDto> models = await productService.GetAllAsync();
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductDto model = await productService.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ProductDto model = await productService.GetById(id);
            return View(model);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Edit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.TryGetValue("Token", out byte[] token);

                var response = await productService.Update(model, Encoding.ASCII.GetString(token));
                if (response)
                {
                    return RedirectToAction(nameof(ManageProducts));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Something went wrong");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            HttpContext.Session.TryGetValue("Token", out byte[] token);

            await productService.Delete(id, Encoding.ASCII.GetString(token));

            return RedirectToAction(nameof(ManageProducts));
        }
    }
}