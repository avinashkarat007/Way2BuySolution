using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;
using Way2Buy.DataPersistenceLayer.Concrete;

namespace Way2Buy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _dbCategoryRepository;

        public CategoryController()
        {
            
        }

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._dbCategoryRepository = categoryRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_dbCategoryRepository.Categories);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CategoryDescription,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                _dbCategoryRepository.SaveCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _dbCategoryRepository.GetCategory(id);

            return View(category);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,CategoryDescription,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                _dbCategoryRepository.SaveCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _dbCategoryRepository.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _dbCategoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
