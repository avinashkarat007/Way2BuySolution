using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;
using Way2Buy.HTMLHelpers;
using Way2Buy.Models;

namespace Way2Buy.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _dbContextProductRepository;

        private readonly ICategoryRepository _dbContextCategoryRepository;
        

        public ProductController(IProductRepository dbContextProductRepository, ICategoryRepository dbContextCategoryRepository)
        {
            _dbContextProductRepository = dbContextProductRepository; 
            _dbContextCategoryRepository = dbContextCategoryRepository;
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index(string nameSearch, int page = 1, int pageSize = 5)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                nameSearch = nameSearch.Trim().ToLower();
            }

            var model = new ProductListViewModel
            {
                Products = _dbContextProductRepository.Products
                    .Where(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == "")
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = _dbContextProductRepository.Products.Count(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == ""),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                }
            };

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post|HttpVerbs.Get)]
        public ActionResult GetSearchActionResult(string nameSearch, int page = 1, int pageSize = 5)
        {            
            if (!string.IsNullOrEmpty(nameSearch))
            {
                nameSearch = nameSearch.Trim().ToLower();
            }

            var model = new ProductListViewModel
            {
                Products = _dbContextProductRepository.Products
                    .Where(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == "")
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = _dbContextProductRepository.Products.Count(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == ""),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                }
            };

            return PartialView("ProductListPartial", model);
        }
        
        public JsonResult GetProductNames(string term)
        {
            List<string> productNames = _dbContextProductRepository.Products
                .Where(x => x.Name.ToLower().Trim().StartsWith(term))
                .Select(x => x.Name)
                .ToList();

            return Json(productNames, JsonRequestBehavior.AllowGet);
        }

        // GET: Product/Create
        public ActionResult Create(int? productId)
        {
            var model = new ProductViewModel();
            var categories = _dbContextCategoryRepository.Categories.ToList();
            model.Categories = categories;
            if (productId.HasValue)
            {
                var product = _dbContextProductRepository.GetProduct(productId.Value);
                model.Product = product;
            }
            return View("Save", model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Save(Product product, HttpPostedFileBase image = null)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();


            if (image != null)
            {
                product.ImageMimeType = image.ContentType;
                product.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

            _dbContextProductRepository.SaveProduct(product);
            
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5        
        public ActionResult Delete(int productId)
        {
            var product = _dbContextProductRepository.GetProduct(productId);
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
