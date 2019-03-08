﻿using System;
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
    public class ProductController : Controller
    {
        private readonly IProductRepository _dbContextProductRepository;

        private readonly ICategoryRepository _dbContextCategoryRepository;

        public int PageSize = 5;

        public ProductController(IProductRepository dbContextProductRepository, ICategoryRepository dbContextCategoryRepository)
        {
            _dbContextProductRepository = dbContextProductRepository; 
            _dbContextCategoryRepository = dbContextCategoryRepository;
        }

        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var model = new ProductListViewModel
            {
                Products = _dbContextProductRepository.Products                    
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = _dbContextProductRepository.Products.Count(),
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                }
            };

            return View(model);
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
