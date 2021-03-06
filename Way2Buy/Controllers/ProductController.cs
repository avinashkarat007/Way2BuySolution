﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessServiceLayer.Abstract;
using Logger.Abstract;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.HTMLHelpers;
using Way2Buy.Models;

namespace Way2Buy.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger _logService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            // _logService = logService;
        }

        /* The below contructor is not working. Need to find out why. */
        /*public ProductController(IProductService productService, ILogger logService)
        {
            _productService = productService;
            _logService = logService;
        }*/

        /*public ProductController(ILogger logService)
        {
            // _productService = productService;
            _logService = logService;
        }*/

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index(string nameSearch, int page = 1, int pageSize = 5)
        {
            // _logService.LogMessage("Product added successfully");
            var model = GetProductListViewModel(nameSearch, page, pageSize);        
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post|HttpVerbs.Get)]
        public ActionResult GetSearchResults(string nameSearch, int page = 1, int pageSize = 5)
        {
            var model = GetProductListViewModel(nameSearch, page, pageSize);
            return PartialView("ProductListPartial", model);
        }

        public ActionResult Create(int? productId)
        {
            var model = new ProductViewModel();
            var categories = _productService.GetCategories();
            model.Categories = categories;
            if (productId.HasValue)
            {
                var product = _productService.GetProduct(productId.Value);
                model.Product = product;
            }
            return View("Save", model);
        }

        // POST: Product/Save
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

            _productService.SaveProduct(product);
            // _logService.LogMessage("Product added successfully");
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5        
        public ActionResult Delete(int productId)
        {
            var product = _productService.GetProduct(productId);
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
            var category = _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetProductNames(string term)
        {
            List<string> productNames = _productService.Products
                .Where(x => x.Name.ToLower().Trim().StartsWith(term))
                .Select(x => x.Name)
                .ToList();

            return Json(productNames, JsonRequestBehavior.AllowGet);
        }
                
        public FileContentResult GetImage(int productId)
        {
            var prod = _productService.GetProduct(productId);

            return prod != null ? File(prod.ImageData, prod.ImageMimeType) : null;
        }

        private ProductListViewModel GetProductListViewModel(string nameSearch, int page = 1, int pageSize = 5)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                nameSearch = nameSearch.Trim().ToLower();
            }

            var model = new ProductListViewModel
            {
                Products = _productService.Products
                    .Where(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == "")
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = _productService.Products.Count(p => p.Name.ToLower().Trim().Contains(nameSearch ?? string.Empty) || nameSearch == null || nameSearch == ""),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                }
            };
            return model;
        }
    }
}
