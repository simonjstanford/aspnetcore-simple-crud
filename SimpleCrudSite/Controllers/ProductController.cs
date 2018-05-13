using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudSite.Models;

namespace SimpleCrudSite.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "All Products";
            var products = DataSource.GetProducts();
            return View(products);
        }

        public IActionResult IndexByTypeID(int id)
        {
            var type = DataSource.GetProductTypeByID(id);
            ViewData["Title"] = $"Products of {type}";
            var products = DataSource.GetProductsByTypeID(id);
            return View(nameof(Index), products);
        }

        public IActionResult ShowDetail(int id)
        {
            var product = DataSource.GetProductByID(id);
            if (product != null)
                return View("Detail", product);
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
                DataSource.AddProduct(product);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = DataSource.GetProductByID(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
                DataSource.UpdateProductByID(product.ID, product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            DataSource.RemoveProductByID(id);
            return RedirectToAction(nameof(Index));
        }
    }
}