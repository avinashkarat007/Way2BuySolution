using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;
using Way2Buy.Models;

namespace Way2Buy.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _dbContextProductRepository;

        public ProductController(IProductRepository dbContextProductRepository)
        {
            _dbContextProductRepository = dbContextProductRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _dbContextProductRepository.Products.ToList();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _dbContextProductRepository.SaveProduct(product);
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _dbContextProductRepository.GetProduct(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid) return View(product);
                _dbContextProductRepository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _dbContextProductRepository.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _dbContextProductRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
