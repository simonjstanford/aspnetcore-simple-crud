using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudSite.Models;

namespace SimpleCrudSite.Controllers
{
    public class ProductTypeController : Controller
    {
        public IActionResult Index()
        {
            var types = DataSource.GetProductTypes();
            return View(types);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType type)
        {
            if (ModelState.IsValid) {
                DataSource.AddProductType(type);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var type = DataSource.GetProductTypeByID(id);
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(ProductType type)
        {
            if (ModelState.IsValid)
            {
                DataSource.UpdateProductTypeByID(type.ID, type);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            DataSource.RemoveProductTypeByID(id);
            return RedirectToAction(nameof(Index));
        }
    }
}