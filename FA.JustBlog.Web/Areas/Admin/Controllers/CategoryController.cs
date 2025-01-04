using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Authorization;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Web.Areas.Admin.Models.Category;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Category
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Index()
        {
            var category = _unitOfWork.Categories.GetAll();
            return View(category);
        }

        // GET: Admin/Category/Details/5
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.Categories.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Create([Bind("Name,UrlSlug,Description")] CategoryCreateModel category)
        {
            if (ModelState.IsValid)
            {
                // Chuyển dữ liệu từ CategoryCreateModel sang Category (nếu cần)
                var newCategory = new Category
                {
                    Name = category.Name,
                    UrlSlug = category.UrlSlug,
                    Description = category.Description
                };

                _unitOfWork.Categories.Add(newCategory);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        // GET: Admin/Category/Edit/5
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.Categories.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            // Chuyển đổi từ Category sang CategoryEditModel
            var categoryEditModel = new CategoryEditModel
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description
            };

            return View(categoryEditModel);
        }


        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Edit(int id, [Bind("Id,Name,UrlSlug,Description")] CategoryEditModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var category2 = _unitOfWork.Categories.Find(category.Id);
                    category2.Name = category.Name; 
                    category2.UrlSlug = category.UrlSlug;
                    category2.Description = category.Description;
                    _unitOfWork.Categories.Update(category2);
                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        [Authorize(Roles = "BlogOwner")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.Categories.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BlogOwner")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _unitOfWork.Categories.Find(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _unitOfWork.Categories.Find(id) != null;
        }
    }
}
