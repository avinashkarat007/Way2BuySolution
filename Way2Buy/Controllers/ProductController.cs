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

        private readonly ICategoryRepository _dbContextCategoryRepository;

        public ProductController(IProductRepository dbContextProductRepository, ICategoryRepository dbContextCategoryRepository)
        {
            _dbContextProductRepository = dbContextProductRepository;
            _dbContextCategoryRepository = dbContextCategoryRepository;
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
            var categories = _dbContextCategoryRepository.Categories.ToList();
            var model = new ProductViewModel {Categories = categories};
            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase image = null)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                _dbContextProductRepository.SaveProduct(product);
            }
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

        public FileContentResult GetImage(int productId)
        {
            var prod = _dbContextProductRepository.GetProduct(productId);

            return prod != null ? File(prod.ImageData, prod.ImageMimeType) : null;
        }
    }
}
