using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Web.Areas.Admin.Models.Tag;
using Azure;
using FA.JustBlog.Web.Areas.Admin.Models.Category;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Tag
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Index()
        {
            var tags = _unitOfWork.Tags.GetAll();
            return View(tags);
        }

        // GET: Admin/Tag/Details/5
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _unitOfWork.Tags.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Admin/Tag/Create
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Create([Bind("Name,UrlSlug,Description")] TagCreateModel tag)
        {
          
            if (ModelState.IsValid)
            {
                var newTag = new Tag
                {
                    Name = tag.Name,
                    UrlSlug = tag.UrlSlug,
                    Description = tag.Description,
                    Count = 0
                };
                _unitOfWork.Tags.Add(newTag);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        // GET: Admin/Tag/Edit/5
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _unitOfWork.Tags.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }
            var tagEditModel = new TagEditModel
            {
                Id = tag.Id,
                Name = tag.Name,
                UrlSlug = tag.UrlSlug,
                Description = tag.Description
            };
            return View(tagEditModel);
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Edit(int id, [Bind("Id,Name,UrlSlug,Description,Count")] TagEditModel tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingTag = _unitOfWork.Tags.Find(tag.Id);
                    if (existingTag == null)
                    {
                        return NotFound();
                    }

                    existingTag.Name = tag.Name;
                    existingTag.UrlSlug = tag.UrlSlug;
                    existingTag.Description = tag.Description;
                   
                    _unitOfWork.Tags.Update(existingTag);
                    _unitOfWork.SaveChanges();
                }
                catch
                {
                    if (!TagExists(tag.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        // GET: Admin/Tag/Delete/5
        [Authorize(Roles = "BlogOwner")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _unitOfWork.Tags.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Admin/Tag/Delete/5
        [Authorize(Roles = "BlogOwner")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tag = _unitOfWork.Tags.Find(id);
            if (tag != null)
            {
                _unitOfWork.Tags.Delete(tag);
                _unitOfWork.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _unitOfWork.Tags.Find(id)!=null;
        }
    }
}
