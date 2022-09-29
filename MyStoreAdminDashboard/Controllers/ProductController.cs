using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.Create(model);

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

        public async Task<IActionResult> ManageProducts()
        {
            List<ProductDto> models = await productService.GetAllAsync();
            return View(models);
        }

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

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.Update(model);
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

        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return RedirectToAction(nameof(ManageProducts));
        }

    }
}